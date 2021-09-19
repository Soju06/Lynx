using Lynx.Common.Components;

namespace Lynx.Logger.Interface {
    public interface ILoggableComponent : IComponent {
        /// <summary>
        /// 로거
        /// </summary>
        ILogger Logger { get; set; }
    }
}
