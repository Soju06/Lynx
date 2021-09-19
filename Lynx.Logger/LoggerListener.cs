namespace Lynx.Logger {
    /// <summary>
    /// 로거 리스너
    /// </summary>
    public abstract class LoggerListener : IDisposable {
        protected bool disposedValue;

        public LoggerListener(LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) {
            DetailLevel = detailLevel; TraceLevel = traceLevel;
        }

        /// <summary>
        /// 추적을 로깅합니다. 
        /// </summary>
        public virtual void Trace(string rootName, LoggerTrace trace) {
            if (trace.Equals(default)) return;
            if ((sbyte)trace.Status <= (sbyte)TraceLevel)
                RawTrace((rootName.IsNullOrWhiteSpace() ? null : rootName + " ") + trace.GetTrace(DetailLevel));
        }

        /// <summary>
        /// 이름
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// 원시 데이터
        /// </summary>
        public abstract void RawTrace(string data);

        /// <summary>
        /// 버퍼를 모두 적용합니다.
        /// </summary>
        public abstract void Flush();

        /// <summary>
        /// 상세 레벨
        /// </summary>
        public LoggerDetailLevel DetailLevel { get; protected set; }

        /// <summary>
        /// 추적 레벨
        /// </summary>
        public LoggerStatus TraceLevel { get; protected set; }

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
}
