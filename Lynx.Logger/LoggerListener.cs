namespace Lynx.Logger {
    /// <summary>
    /// 로거 리스너
    /// </summary>
    public abstract class LoggerListener {
        public LoggerListener(LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) {
            DetailLevel = detailLevel; TraceLevel = traceLevel;
        }

        public 

        /// <summary>
        /// 상세 레벨
        /// </summary>
        public LoggerDetailLevel DetailLevel { get; protected set; }

        /// <summary>
        /// 추적 레벨
        /// </summary>
        public LoggerStatus TraceLevel { get; protected set; }
    }
}
