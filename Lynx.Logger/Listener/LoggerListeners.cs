using Lynx.Logger.Interface;
using System.Diagnostics;

namespace Lynx.Logger.Listener {
    public static class LoggerListeners {
        /// <summary>
        /// TextWriter 리스너를 추가합니다.
        /// </summary>
        public static ILoggerFactory AddTextWriterListener(this ILoggerFactory Factory, TextWriter writer, string name = null,
            LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) =>
            Factory.AddListener(new LoggerTextWriterListener(writer, name, detailLevel, traceLevel));

        /// <summary>
        /// 추적 리스너를 추가합니다.
        /// </summary>
        public static ILoggerFactory AddTraceListener(this ILoggerFactory Factory, TraceListener listener, string name = null,
            LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) =>
            Factory.AddListener(new LoggerTraceListener(listener, name, detailLevel, traceLevel));

        /// <summary>
        /// TextWriter 리스너를 추가합니다.
        /// </summary>
        public static ILoggerFactory AddConsoleListener(this ILoggerFactory Factory, string name = null,
            LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) =>
            Factory.AddListener(new LoggerTextWriterListener(Console.Out, name, detailLevel, traceLevel));
    }
}
