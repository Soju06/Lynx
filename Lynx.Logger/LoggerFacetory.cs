using Lynx.Common;
using Lynx.Logger.Interface;
using System.Collections;
using System.Diagnostics;

namespace Lynx.Logger {
    public class LoggerFacetory : Component, ILoggerFacetory {
        public TraceListenerCollection TraceListener { get; } = new();

        public void AddListener(TraceListener listener) => TraceListener.Add(listener);

        public ILogger CreateLogger(string name) => new Logger(this, name);

        public void Log(ILogger logger, LoggerTrace trace) {
        }

        public void RemoveListener(TraceListener listener) => TraceListener.Remove(listener);

        public void RemoveListener(string listenerName) => TraceListener.Remove(listenerName);
    }
}
