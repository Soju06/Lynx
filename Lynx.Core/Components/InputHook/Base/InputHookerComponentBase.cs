using Lynx.Common.Components;
using Lynx.Common.Interface;
using Lynx.Core.Components.Interface;
using Lynx.Logger.Interface;

namespace Lynx.Core.Components.InputHook.Base {
    /// <summary>
    /// 인풋 후커
    /// </summary>
    public abstract class InputHookerComponentBase : SwitchableComponent, IInputHookerComponentBase {
        public override bool CanStop { get; } = true;

        public override bool CanPause { get; } = true;

        public virtual ILogger Logger { get; set; }

        /// <summary>
        /// 키보드
        /// </summary>
        public KeyboardModel KeyboardModel { get; set; }

        public override SwitchState OnStateChange(SwitchState state) {
            if(State != state) {
                switch (state) {
                    case SwitchState.Running: HookStart(); break;
                    case SwitchState.Paused:  HookStop();  break;
                    case SwitchState.Stoped:  HookStop();  break;
                }
            } return state;
        }

        /// <summary>
        /// 후킹 시작
        /// </summary>
        protected virtual void HookStart() {

        }

        /// <summary>
        /// 후킹 일시 정지
        /// </summary>
        protected virtual void HookPause() {

        }

        /// <summary>
        /// 후킹 정지
        /// </summary>
        protected virtual void HookStop() {

        }

        void IInputHookerComponentBase.HookStart() => HookStart();

        void IInputHookerComponentBase.HookStop() => HookStop();

        void IInputHookerComponentBase.HookPause() => HookPause();

        public virtual void OnLoggerInited(ILogger logger) {

        }
    }
}
