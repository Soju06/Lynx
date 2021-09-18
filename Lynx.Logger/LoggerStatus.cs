namespace Lynx.Logger {
    /// <summary>
    /// 로거 상태
    /// </summary>
    public enum LoggerStatus : sbyte {
        /// <summary>
        /// 메시지
        /// </summary>
        MESG = -1,
        /// <summary>
        /// 인포
        /// </summary>
        INFO = 0,
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
