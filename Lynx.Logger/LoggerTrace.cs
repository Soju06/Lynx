namespace Lynx.Logger {
    /// <summary>
    /// 로거 트레이스
    /// </summary>
    public struct LoggerTrace {
        public LoggerTrace(object detail, string name = null, LoggerStatus status = 0) {
            Time = DateTime.Now;
            Detail = detail;
            Name = name;
            Status = status;
        }

        /// <summary>
        /// 시간
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// 세부 사항
        /// </summary>
        public object Detail { get; set; }

        /// <summary>
        /// 상태
        /// </summary>
        public LoggerStatus Status { get; set; }

        /// <summary>
        /// 구분 이름
        /// </summary>
        public string Name { get; set; }

        public string TimeString => Time.ToString("MM/dd/yy HH:mm:ss");

        public override string ToString() => $"[{Name?.Append(" ")}{TimeString}] [{Status}] {Detail}";
    }
}
