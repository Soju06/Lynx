using Lynx.App;
using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Components;
using Lynx.Core;
using Lynx.Interface;
using Lynx.Logger;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;
using Lynx.Logger.Listener;

namespace Lynx {
    public class LynxApplication : Component, ILoggableComponent {
        [LoggerName("Lynx")]
        public ILogger Logger { get; set; }

        public LynxApplication(string platformName) {
            PlatformName = platformName;
            this.AddLoggerFactory(lf => 
                (LoggerFactory = lf)
                    .AddConsoleListener(null, LoggerDetailLevel.DateTraceMessage, LoggerStatus.EXPN)
                    .AppendLogger(this), 
                "Lynx");
            Logger.Log($@"
┃                                                         ┃
┃  ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓  ┃
┃  ┃    __         __  __     __   __     __  __       ┃  ┃
┃  ┃   /\ \       /\ \_\ \   /\ \-.\ \   /\_\_\_\      ┃  ┃
┃  ┃   \ \ \____  \ \____ \  \ \ \-.  \  \/_/\_\/_     ┃  ┃
┃  ┃    \ \_____\  \/\_____\  \ \_\\-\_\   /\_\/\_\    ┃  ┃
┃  ┃     \/_____/   \/_____/   \/_/ \/_/   \/_/\/_/    ┃  ┃
┃  ┃                                                   ┃  ┃
┃  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛  ┃
┃                                                         ┃
            Platfrom: {platformName}".CaptureMake(), LoggerStatus.MESG);
        }

        /// <summary>
        /// 로거 팩토리
        /// </summary>
        public ILoggerFactory LoggerFactory { get; private set; }

        /// <summary>
        /// 플렛폼
        /// </summary>
        public string PlatformName { get; private set; }

        void InitializeComponent() {
            Components.Add(new LynxApp(PlatformName));
            Components.Add(new LynxCore());
            this.AppendLogger();
        }

        public void Run() {
            InitializeComponent();
            this.GetComponent<LynxApp>().Run()();
        }

        public void OnLoggerInited(ILogger logger) {

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
