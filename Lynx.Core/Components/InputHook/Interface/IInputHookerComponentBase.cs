using Lynx.Common.Interface;
using Lynx.Core.Components.InputHook;
using Lynx.Logger.Interface;

namespace Lynx.Core.Components.Interface {
    public interface IInputHookerComponentBase : ISwitchableComponent, ILoggableComponent {
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

        /// <summary>
        /// 키보드
        /// </summary>
        KeyboardModel KeyboardModel { get; set; }
    }
}
