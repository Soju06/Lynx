using Eto.Drawing;
using Eto.Forms;
using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Components;
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
            Application = new(platformName);
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
            Components.Add(new Indicator());
            this.GetComponent<IIndicator>().SetTitle("test tray icon");
            this.GetComponent<IIndicator>().SetImage(new Bitmap(32, 32, PixelFormat.Format32bppRgba));
            this.GetComponent<IIndicator>().SetMemu(new(new[] { new ButtonMenuItem() { Text = "TestMenuItem" } }));
            this.GetComponent<IIndicator>().Show();
        }

        public void Run() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {

            }
            base.Dispose(disposing);
        }
    }
}
