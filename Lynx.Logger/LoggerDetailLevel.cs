namespace Lynx.Logger {
    /// <summary>
    /// 상세 레벨
    /// </summary>
    public enum LoggerDetailLevel : byte {
        /// <summary>
        /// 전부
        /// </summary>
        Full = 0,
        /// <summary>
        /// 시간 추적 메시지
        /// </summary>
        DateTraceMessage = 1,
        /// <summary>
        /// 시간 메시지
        /// </summary>
        DateMessage = 2,
        /// <summary>
        /// 메시지
        /// </summary>
        Message = 3,
    }
}
