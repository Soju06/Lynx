using System.Diagnostics;

namespace Lynx.Logger.Listener {
    /// <summary>
    /// 트레이스 리스너 지원
    /// </summary>
    public class LoggerTraceListener : LoggerListener {
        readonly TraceListener listener;

        public LoggerTraceListener(TraceListener listener, string name = null, 
            LoggerDetailLevel detailLevel = 0, LoggerStatus traceLevel = 0) : base(detailLevel, traceLevel) {
            this.listener = listener; Name = name;
        }

        public override string Name { get; set; }

        public override void Flush() => listener.Flush();

        public override void RawTrace(string data) => 
            listener.WriteLine(data);

        public void Dispose(int traceListenerDispose) {
            if (traceListenerDispose > 0) {
                listener?.Flush();
                listener?.Dispose();
            } Dispose();
        }
    }
}
