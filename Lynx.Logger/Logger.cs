using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;
using System.Reflection;

namespace Lynx.Logger {
    /// <summary>
    /// 로거
    /// </summary>
    public class Logger : ILogger {
        protected bool disposedValue;

        internal Logger(ILoggerFactory factory, string name) {
            Factory = factory; Name = name;
        }

        /// <summary>
        /// 팩토리
        /// </summary>
        public ILoggerFactory Factory { get; }

        /// <summary>
        /// 이름
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// 추적을 만듭니다.
        /// </summary>
        public virtual void Log(object detail, LoggerStatus status = 0, string name = null) =>
            Log(new(detail, name, status));

        /// <summary>
        /// 로깅합니다.
        /// </summary>
        public virtual void Log(LoggerTrace trace) => Factory.Log(this, trace);

        /// <summary>
        /// 로거를 생성합니다.
        /// </summary>
        public static Logger Create(ILoggerFactory Factory, string name) => new(Factory, name);

        public virtual ILogger CreateLogger(string name) => Factory.CreateLogger($"{Name}/{name}");

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


    public static class LoggerStatic {
        public static ILogger AppendLogger(this ILogger logger, ILoggableComponent component) {
            AppendLogger((ILoggerBase)logger, component);
            return logger;
        }
        
        public static ILogger AppendLogger(this ILogger logger, ComponentCollection components) {
            AppendLogger((ILoggerBase)logger, components);
            return logger;
        }
        
        public static ILoggerFactory AppendLogger(this ILoggerFactory logger, ILoggableComponent component) {
            AppendLogger((ILoggerBase)logger, component);
            return logger;
        }
        
        public static ILoggerFactory AppendLogger(this ILoggerFactory logger, ComponentCollection components) {
            AppendLogger((ILoggerBase)logger, components);
            return logger;
        }
        
        public static ILoggableComponent AppendLogger(this ILoggableComponent lcomponent, ILoggableComponent component) {
            AppendLogger((ILoggerBase)lcomponent.Logger, component);
            return lcomponent;
        }
        
        public static ILoggableComponent AppendLogger(this ILoggableComponent lcomponent, ComponentCollection components) {
            AppendLogger((ILoggerBase)lcomponent.Logger, components);
            return lcomponent;
        }
        
        public static ILoggableComponent AppendLogger(this ILoggableComponent component) {
            AppendLogger(component, component.Components);
            return component;
        }

        public static ILoggerBase AppendLogger(this ILoggerBase logger, ILoggableComponent component) {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (component == null) throw new ArgumentNullException(nameof(component));
            var type = component.GetType();
            var field = type.GetProperty(nameof(component.Logger));
            var name = field.GetCustomAttribute<LoggerNameAttribute>()?.Name;
            var clogger = logger.CreateLogger(name);
            field.SetValue(component, clogger);
            component.OnLoggerInited(clogger);
            return null;
        }

        public static ILoggerBase AppendLogger(this ILoggerBase logger, ComponentCollection components) {
            components.GetComponents<ILoggableComponent>().Foreach(e => AppendLogger(logger, e));
            return logger;
        }
    }
}
