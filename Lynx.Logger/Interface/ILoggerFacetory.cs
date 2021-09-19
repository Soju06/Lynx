using Lynx.Common.Components;

namespace Lynx.Logger.Interface {
    /// <summary>
    /// 로거 팩토리
    /// </summary>
    public interface ILoggerFactory : ILoggerBase {
        /// <summary>
        /// 로깅합니다.
        /// </summary>
        void Log(ILogger logger, LoggerTrace trace);

        /// <summary>
        /// 추적 리스너
        /// </summary>
        LoggerListenerCollection LoggerListener { get; }

        /// <summary>
        /// 리스너 추가
        /// </summary>
        public ILoggerFactory AddListener(LoggerListener listener);
        /// <summary>
        /// 리스너 제거
        /// </summary>
        public bool RemoveListener(LoggerListener listener);
        /// <summary>
        /// 리스너 제거
        /// </summary>
        public bool RemoveListener(string listenerName);
    }
}
