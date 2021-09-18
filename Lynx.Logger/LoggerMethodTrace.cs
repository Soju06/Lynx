using System.Diagnostics;
using System.Reflection;

namespace Lynx.Logger {
    /// <summary>
    /// 로거 트랙
    /// </summary>
    public struct LoggerMethodTrace {
        public LoggerMethodTrace(StackFrame stack, string message = null, bool traceClassName = true, bool traceMethodName = true) {
            FileName = stack.GetFileName();
            FileLineNumber = stack.GetFileLineNumber();
            Method = stack.GetMethod();
            TraceClassName = traceClassName;
            TraceMethodName = traceMethodName;
            Message = message;
        }

        /// <summary>
        /// 파일 이름
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// 라인
        /// </summary>
        public int FileLineNumber { get; set; }

        /// <summary>
        /// class 로깅 여부
        /// </summary>
        public bool TraceClassName { get; set; }
        /// <summary>
        /// 클래스 이름
        /// </summary>
        public string ClassName => Method?.ReflectedType?.Name;

        /// <summary>
        /// method 로깅 여부
        /// </summary>
        public bool TraceMethodName { get; set; }
        /// <summary>
        /// 메소드 이름
        /// </summary>
        public string? MethodName => Method?.Name;

        /// <summary>
        /// 매소드
        /// </summary>
        public MethodBase? Method { get; set; }

        public string Message { get; private set; }

        string GetFileInfo => FileName.IsNullOrWhiteSpace() ? null : $"{FileName}:{FileLineNumber}";
        string GetTraceInfo => $"{(TraceClassName ? ClassName + "/" : null)}{(TraceMethodName ? MethodName : null)}";

        public override string ToString() => $"{GetFileInfo}{(!TraceClassName && !TraceMethodName ? GetTraceInfo : null)} {Message}";

        public static implicit operator string(LoggerMethodTrace trace) => trace.ToString();

        public static LoggerMethodTrace Make(StackFrame stack, Exception exception, string message) =>
            new(stack, exception.ToString() + " | " + message);

        public static LoggerMethodTrace Make(StackFrame stack, string message) =>
            new(stack, message);

        public static LoggerMethodTrace CaptureMake(string message) =>
            Make(new StackFrame(1, true), message);

        public static LoggerMethodTrace CaptureMake(Exception exception, string message) =>
            Make(new StackFrame(1, true), exception, message);
    }

    public static class LoggerMethodTraceStatic {
        public static LoggerMethodTrace Make(this Exception exception, StackFrame stack, string message) =>
            LoggerMethodTrace.Make(stack, exception, message);

        public static LoggerMethodTrace CaptureMake(this string message) =>
            LoggerMethodTrace.CaptureMake(message);

        public static LoggerMethodTrace CaptureMake(this Exception exception, string message) =>
            LoggerMethodTrace.CaptureMake(exception, message);
    }
}