using Lynx.Common.Interface;

namespace Lynx.Core.Components.InputHook.Interface {
    /// <summary>
    /// 인풋 후킹 컴포넌트
    /// </summary>
    public interface IInputHookComponent : ISwitchableComponent {
        /// <summary>
        /// 인풋 후커
        /// </summary>
        IInputHookerComponentBase InputHooker { get; set; }

        /// <summary>
        /// 인풋 후커
        /// </summary>
        /// <returns></returns>
        IInputHookerComponentBase GetInputHooker();

        /// <summary>
        /// 인풋 후커
        /// </summary>
        /// <returns></returns>
        IInputHookerComponentBase SetInputHooker(IInputHookerComponentBase inputHooker);
    }
}
