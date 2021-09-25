using Lynx.Common;
using Lynx.Common.Components;
using Lynx.Logger.Interface;
using Soju06.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Lynx.Logger {
    public class LoggerFactory : Component, ILoggerFactory {
        readonly CancellationTokenSource tokenSource = new();
        readonly ConcurrentQueue<LoggerTrace> traceQueue = new();
        readonly Task task;

        public LoggerFactory(string name = null) {
            task = Repeat.Interval(TimeSpan.FromMilliseconds(50), 
                LoggerLoop, tokenSource.Token);
            Name = name;
        }

        protected virtual void LoggerLoop() {
            try {
                if (!traceQueue.TryDequeue(out var trace)) return;
                var listenerCount = LoggerListener.Count;
                for (int i = 0; i < listenerCount; i++) {
                    var listener = LoggerListener[i];
                    try {
                        listener.Trace(Name, trace);
                    } catch (Exception ex) {
                        Debug.Assert(false, $"== logger listener exception ==\nName: {listener.Name}\nException: {ex}");
                    }
                }
            } catch (Exception ex) {
                Trace.Assert(false, $"== logger factory exception ==\nException: {ex}");    
            }
        }

        public LoggerListenerCollection LoggerListener { get; } = new();

        public virtual ILoggerFactory AddListener(LoggerListener listener) {
            LoggerListener.Add(listener);
            return this;
        }

        public virtual ILogger CreateLogger(string name) => new Logger(this, name);

        public virtual void Log(ILogger logger, LoggerTrace trace) {
            trace.Name = logger.Name + (trace.Name.IsNullOrWhiteSpace() ? null : "/" + trace.Name) ?? "null";
            traceQueue.Enqueue(trace);
        }
        
        public virtual void Log(LoggerTrace trace) =>
            traceQueue.Enqueue(trace);

        public virtual bool RemoveListener(LoggerListener listener) =>
            LoggerListener.Remove(listener);

        public virtual bool RemoveListener(string listenerName) => 
            LoggerListener.Remove(listenerName);

        /// <summary>
        /// 현재 로거
        /// </summary>
        public static LoggerFactory Current => current ??= new();

        static LoggerFactory current;

        protected override void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    try {
                        tokenSource?.Cancel();
                        task?.Wait(500);
                        tokenSource?.Dispose();
                        task?.Dispose();
                    } catch {

                    }
                }
            } base.Dispose(disposing);
        }
    }

    public static class LoggerFactoryStatic {
        public static IComponent AddLoggerFactory(this IComponent component, string name = null) {
            component.AddComponent(new LoggerFactory(name));
            return component;
        }
        
        public static IComponent AddLoggerFactory(this IComponent component, 
            Action<LoggerFactory> action, string name = null) {
            var Factory = new LoggerFactory(name);
            action?.Invoke(Factory);
            component.AddComponent(Factory);
            return component;
        }
    }
}
