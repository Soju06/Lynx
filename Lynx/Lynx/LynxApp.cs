using Eto.Drawing;
using Eto.Forms;
using Lynx.Component;
using Lynx.Interface;
using System.Diagnostics;

namespace Lynx {
    public class LynxApp : Component.Component {
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
        public Application Application { get; private set; }

        void InitializeComponent() {
            Components.Add(new Indicator());
            GetComponent<Indicator>().SetTitle("test tray icon");
            var b = new Bitmap(32, 32, PixelFormat.Format32bppRgba);
            using (var g = new Graphics(b)) {
                g.AntiAlias = true;
                g.DrawArc(Color.FromArgb(000_000_000_255), new RectangleF(0, 0, 32, 32), 1, 1);
            }
            GetComponent<Indicator>().SetImage(b);
            GetComponent<Indicator>().SetMemu(new ContextMenu(new MenuItem[] { new ButtonMenuItem() { Text = "TestMenuItem" } }));
            GetComponent<Indicator>().Show();
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
