using Lynx.Logger.Interface;

namespace Lynx.Logger {
    /// <summary>
    /// 로거
    /// </summary>
    public class Logger : ILogger {
        internal Logger(ILoggerFacetory facetory, string name) {
            Facetory = facetory; Name = name;
        }

        /// <summary>
        /// 팩토리
        /// </summary>
        public ILoggerFacetory Facetory { get; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 추적을 만듭니다.
        /// </summary>
        public LoggerTrace MakeTrace(LoggerStatus status, object detail) =>
            new(detail, Name, status);

        /// <summary>
        /// 로깅합니다.
        /// </summary>
        public void Log(LoggerTrace trace) => Facetory.Log(this, trace);

        /// <summary>
        /// 로거를 생성합니다.
        /// </summary>
        public static Logger Create(ILoggerFacetory facetory, string name) => new(facetory, name);
    }
}
