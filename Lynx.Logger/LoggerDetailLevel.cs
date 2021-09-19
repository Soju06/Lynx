namespace Lynx.Logger {
    /// <summary>
    /// 상세 레벨
    /// </summary>
    public enum LoggerDetailLevel : byte {
        /// <summary>
        /// 메시지
        /// </summary>
        Message = 0,
        /// <summary>
        /// 시간 메시지
        /// </summary>
        DateMessage = 1,
        /// <summary>
        /// 시간 추적 메시지
        /// </summary>
        DateTraceMessage = 2,
        /// <summary>
        /// 전부
        /// </summary>
        Full = 3,
    }
}
