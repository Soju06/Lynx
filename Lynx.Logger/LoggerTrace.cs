using System.Reflection;

namespace Lynx.Logger {
    /// <summary>
    /// 로거 트레이스
    /// </summary>
    public struct LoggerTrace {
        public LoggerTrace(object detail, string name = null, LoggerStatus status = 0) {
            Detail = detail;
            Name = name;
            Status = status;
        }
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

        public static string NowTimeString => DateTime.Now.ToString("MM/dd/yy HH:mm:ss");

        /// <summary>
        /// 추적을 만듭니다.
        /// </summary>
        public string GetTrace(LoggerDetailLevel level) {
            var m = level switch {
                LoggerDetailLevel.Message => $"[{Name?.Append(" ")}{Status}] ",
                _ => $"[{Name?.Append(" ")}{NowTimeString}] [{Status}] ",
            };
            var detail = Detail;
            if (detail != null) {
                var method = Detail?.GetType()?.GetMethod("GetTrace", BindingFlags.Public | BindingFlags.InvokeMethod);
                if (method?.ReturnType == typeof(string) && !method.GetParameters().TryGetValue(0, out var p) 
                    && p.ParameterType == typeof(LoggerDetailLevel)) {
                    m += (method.Invoke(detail, new object[] { level }) as string);
                }
            } return m;
        }

        public override string ToString() => GetTrace(LoggerDetailLevel.Full);
    }
}
