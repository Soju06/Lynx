namespace Lynx.Logger.Interface {
    /// <summary>
    /// 로거 베이스
    /// </summary>
    public interface ILoggerBase : IDisposable {
        /// <summary>
        /// 이름
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 로거를 생성합니다.
        /// </summary>
        ILogger CreateLogger(string name);

        /// <summary>
        /// 로깅합니다.
        /// </summary>
        void Log(LoggerTrace trace);
    }
}
