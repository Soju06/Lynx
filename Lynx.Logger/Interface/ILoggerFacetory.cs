using Lynx.Common;
using Lynx.Common.Components;
using System.Diagnostics;

namespace Lynx.Logger.Interface {
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public interface ILoggerFacetory : IComponent {
        /// <summary>
        /// 로깅합니다.
        /// </summary>
        void Log(ILogger logger, LoggerTrace trace);

        /// <summary>
        /// 로거를 생성합니다.
        /// </summary>
        ILogger CreateLogger(string name);

        /// <summary>
        /// 추적 리스너
        /// </summary>
        TraceListenerCollection TraceListener { get; }

        /// <summary>
        /// 리스너 추가
        /// </summary>
        public void AddListener(TraceListener listener);
        /// <summary>
        /// 리스너 제거
        /// </summary>
        public void RemoveListener(TraceListener listener);
        /// <summary>
        /// 리스너 제거
        /// </summary>
        public void RemoveListener(string listenerName);
    }
}
