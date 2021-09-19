using Lynx.Common;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;

namespace Lynx.App {
    /// <summary>
    /// 링크스 GUI 앱
    /// </summary>
    public class LynxApp : Component, ILoggableComponent {
        [LoggerName("App")]
        public ILogger Logger { get; set; }

        public LynxApp() {

        }
    }
}
