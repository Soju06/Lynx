using Eto.Drawing;
using Eto.Forms;
using Lynx.App.Forms;
using Lynx.App.UI.Components;
using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Core;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;
using System.Globalization;

namespace Lynx.App {
    /// <summary>
    /// 링크스 GUI 앱
    /// </summary>
    public class LynxApp : Component, ILoggableComponent {
        [LoggerName("App")]
        public ILogger Logger { get; set; }

        public LynxApp(string platformName) {
            PlatformName = platformName;
            Application = new(platformName);
            Application.Initialized += OnApplicationInitialized;
            InitializeComponent();
        }

        void OnApplicationInitialized(object sender, EventArgs e) =>
            OnApp(null, EventArgs.Empty);

        ManagementUI Management;

        void OpenManagement() =>
            (Management ??= new ManagementUI()).Show();

        void InitializeComponent() {
            this.AddComponent<Indicator>(new(OnApp))
                .SetTitle($"{LynxEnvironment.LynxName} App")
                .SetImage(new Bitmap(Resources.App.LynxSmallIcon))
                .SetMemu(new(new[] { new ButtonMenuItem() { Text = "Quit (&X)" }.Return(menu => menu.Click += OnQuit) }))
                .Return(x => {
                    if (LynxPlatform.IsLinux) x.Menu.Items.Add(new ButtonMenuItem(OnApp) {
                        Text = "Open (&O)"
                    });
                }).Show();
        }

        void OnApp(object sender, EventArgs e) {
            if (LynxPlatform.IsLinux) OpenManagement();
        }

        void OnQuit(object sender, EventArgs e) {
            try {
                Parents?.Dispose();
                Thread.Sleep(500); // flush logger wait
                Application.Quit();
            } catch {

            }
        }

        /// <summary>
        /// UI 스레드를 시작합니다.
        /// </summary>
        public Action Run() => () => {
            Application.Run();
        };

        public void OnLoggerInited(ILogger logger) =>
            UILogger = logger.CreateLogger("UI Thread");

        /// <summary>
        /// 플렛폼
        /// </summary>
        public string PlatformName { get; private set; }

        /// <summary>
        /// 앱
        /// </summary>
        public Application Application { get; private set; }

        public readonly static CultureInfo CurrentCulture = CultureInfo.CreateSpecificCulture("en");

        /// <summary>
        /// ui용 로거
        /// </summary>
        internal static ILogger UILogger { get; private set; }

        protected override void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    Management?.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
