using Eto.Drawing;
using Eto.Forms;
using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Components;
using Lynx.Interface;
using System.Diagnostics;

namespace Lynx {
    public class LynxApp : Component {
        public LynxApp(string platformName) {
            Logger.FileLogging = false;
            Logger.Listeners.Add(new ConsoleTraceListener());
            Logger.Init();
            $@"
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
            Platfrom: {platformName}".Log();
            Application = new(platformName);
        }

        /// <summary>
        /// 플렛폼
        /// </summary>
        public string PlatformName { get; private set; }

        /// <summary>
        /// 앱
        /// </summary>
        public Eto.Forms.Application Application { get; private set; }

        void InitializeComponent() {
            Components.Add(new Indicator());
            this.GetComponent<IIndicator>().SetTitle("test tray icon");
            this.GetComponent<IIndicator>().SetImage(new Bitmap(32, 32, PixelFormat.Format32bppRgba));
            this.GetComponent<IIndicator>().SetMemu(new(new[] { new ButtonMenuItem() { Text = "TestMenuItem" } }));
            this.GetComponent<IIndicator>().Show();
        }

        public void Run() {
            InitializeComponent();
            Application.Run();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                Logger.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
