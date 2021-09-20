using Eto.Drawing;
using Eto.Forms;
using Lynx.App.UI.Components;
using Lynx.App.UI.Interface;
using Lynx.Common;
using Lynx.Common.Linq;
using Lynx.Logger;
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
            InitializeComponent();
        }

        void InitializeComponent() {
            this.AddComponent<Indicator>(new())
                .SetTitle($"{LynxEnvironment.LynxName} App")
                .SetImage(new Bitmap(Resources.App.LynxSmallIcon))
                .SetMemu(new(new[] { new ButtonMenuItem() { Text = "Quit (&X)" }.Return(menu => menu.Click += OnQuit) }))
                .Show();
        }

        void OnQuit(object sender, EventArgs e) =>
            Application.Quit();

        /// <summary>
        /// UI 스레드를 시작합니다.
        /// </summary>
        public Action Run() => () => Application.Run(new Forms.ManagementForm());

        /// <summary>
        /// 플렛폼
        /// </summary>
        public string PlatformName { get; private set; }

        /// <summary>
        /// 앱
        /// </summary>
        public Application Application { get; private set; }

        public readonly static CultureInfo CurrentCulture = CultureInfo.CreateSpecificCulture("en");
    }
}
