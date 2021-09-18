using Lynx.Common.Interface;

namespace Lynx.Core.Components.InputHook.Interface {
    public interface IInputHookerComponentBase : ISwitchableComponent {
        /// <summary>
        /// 후킹 시작
        /// </summary>
        protected void HookStart();
        
        /// <summary>
        /// 후킹 정지
        /// </summary>
        protected void HookStop();

        /// <summary>
        /// 후킹 일시 정지
        /// </summary>
        protected void HookPause();
    }
}
