using Lynx.Common.Components;

namespace Lynx.Logger.Interface {
    public interface ILoggableComponent : IComponent {
        /// <summary>
        /// 로거
        /// </summary>
        ILogger Logger { get; set; }

        /// <summary>
        /// 로거 설정됨
        /// </summary>
        void OnLoggerInited(ILogger logger);
    }
}
