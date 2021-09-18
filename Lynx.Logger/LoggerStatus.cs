namespace Lynx.Logger {
    /// <summary>
    /// 로거 상태
    /// </summary>
    public enum LoggerStatus : byte {
        /// <summary>
        /// 메시지
        /// </summary>
        MESG = 0,
        /// <summary>
        /// 인포
        /// </summary>
        INFO = 1,
        /// <summary>
        /// 경고
        /// </summary>
        WARN = 2,
        /// <summary>
        /// 오류
        /// </summary>
        EROR = 3,
        /// <summary>
        /// 예외
        /// </summary>
        EXPN = 4
    }
}
