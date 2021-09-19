namespace Lynx.Logger.Interface {
    /// <summary>
    /// 로거
    /// </summary>
    public interface ILogger : ILoggerBase {
        /// <summary>
        /// 로거 팩토리
        /// </summary>
        ILoggerFactory Factory { get; }

        /// <summary>
        /// 추적을 만듭니다.
        /// </summary>
        void Log(object detail, LoggerStatus status = 0, string name = null);
    }
}
