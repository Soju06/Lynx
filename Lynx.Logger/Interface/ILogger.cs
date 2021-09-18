namespace Lynx.Logger.Interface {
    /// <summary>
    /// 로거
    /// </summary>
    public interface ILogger {
        /// <summary>
        /// 로거 팩토리
        /// </summary>
        ILoggerFacetory Facetory { get; }

        /// <summary>
        /// 이름
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 추적을 만듭니다.
        /// </summary>
        LoggerTrace MakeTrace(LoggerStatus status, object detail);

        /// <summary>
        /// 로깅합니다.
        /// </summary>
        void Log(LoggerTrace trace);
    }
}
