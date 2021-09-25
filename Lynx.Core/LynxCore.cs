using Lynx.Common.Components;
using Lynx.Common.Interface;
using Lynx.Core.Components;
using Lynx.Core.Components.Interface;
using Lynx.Logger;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;
using Lynx.Logger.Listener;

namespace Lynx.Core {
    /// <summary>
    /// lynx 코어 
    /// </summary>
    public class LynxCore : SwitchableComponent, ILoggableComponent {
        public LynxCore() {
            Components.Add(InputHook = new InputHookComponent());
            this.AddLoggerFactory(lf =>
                (LoggerFactory = lf)
                    .AddConsoleListener(null, LoggerDetailLevel.DateTraceMessage, LoggerStatus.EXPN)
                    .AppendLogger(this),
                "Lynx");
        }

        public override bool CanStop { get; } = true;

        public override bool CanPause { get; } = true;
        
        [LoggerName("Lynx.Core")]
        public ILogger Logger { get; set; }

        /// <summary>
        /// 로거 팩토리
        /// </summary>
        public ILoggerFactory LoggerFactory { get; private set; }

        /// <summary>
        /// 인풋 후커
        /// </summary>
        public IInputHookComponent InputHook { get; private set; }

        bool isInited;

        public void OnLoggerInited(ILogger logger) {
            if (isInited) return;
            isInited = true;
            logger.Log('\n' + LynxPlatform.DiagnosticDetails);
            if (!LynxPlatform.IsLinux &&
                !LynxPlatform.IsWindows &&
                !LynxPlatform.IsOSX) {
                logger.Log($"The current runtime is not supported.".CaptureMake()
                    .Return(x => x.TraceClassName = x.TraceMethodName = true), LoggerStatus.WARN);
            } this.AppendLogger();
        }

        public override SwitchState OnStateChange(SwitchState state) {
            SetChildComponentState(state);
            return state;
        }

        
        protected override void Dispose(bool disposing) {
            if(!disposedValue) {
                if(disposing) {
                    Components.DisposeAll();
                }
            }
            base.Dispose(disposing);
        }
    }
}
