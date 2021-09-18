using Lynx.Logger.Interface;

namespace Lynx.Logger {
    /// <summary>
    /// 로거
    /// </summary>
    public class Logger : ILogger {
        /// <summary>
        /// 팩토리
        /// </summary>
        public LoggerFacetory Facetory { get; private set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; private set; }
    }
}
