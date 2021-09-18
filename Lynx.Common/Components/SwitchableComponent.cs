using Lynx.Common.Interface;
using Lynx.Common.Linq;

namespace Lynx.Common.Components {
    public abstract class SwitchableComponent : Component, ISwitchableComponent {
        /// <summary>
        /// 상태를 Stoped로 변경할 수 있는지 여부입니다.
        /// </summary>
        public abstract bool CanStop { get; }

        /// <summary>
        /// 상태를 Paused로 변경할 수 있는지 여부입니다.
        /// </summary>
        public abstract bool CanPause { get; }

        /// <summary>
        /// 현재 상태입니다.
        /// </summary>
        public virtual SwitchState State { get; protected set; }

        /// <summary>
        /// 현재 상태입니다.
        /// </summary>
        public virtual SwitchState GetState() => State;

        /// <summary>
        /// 상태를 Running으로 변경합니다. (네이티브)
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public virtual bool Resume() => SetState(SwitchState.Running);

        /// <summary>
        /// 상태를 Paused로 변경합니다. (네이티브)
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public virtual bool Pause() => SetState(SwitchState.Paused);

        /// <summary>
        /// 상태를 Stoped로 변경합니다. (네이티브)
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public virtual bool Stop() => SetState(SwitchState.Stoped);
        
        /// <summary>
        /// 설정을 변경합니다.
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public virtual bool SetState(SwitchState state) {
            if ((!CanPause && state == SwitchState.Paused) || (!CanStop && state == SwitchState.Stoped))
                throw new NotSupportedException($"State {state} is not supported by the component."); // 미지원 상태 예외
            var s = State;
            return (State = OnStateChange(State)) == s;
        }

        /// <summary>
        /// 자식 컴포넌트들의 스위치 상태를 set합니다.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected virtual int SetChildComponentState(SwitchState state) {
            int i = 0;
            foreach (var item in this.GetComponents<ISwitchableComponent>()) {
                i++; item.SetState(state);
            } return i;
        }

        /// <summary>
        /// 상태를 지정합니다.
        ///   리턴 값:
        ///     생태 변경 후 현재 상태입니다.
        ///     state와 return값이 같을 경우 네이티브 함수에서 true, 다를경우 false를 반환하게 됩니다.
        /// </summary>
        /// <param name="state">설정할 상태입니다.</param>
        /// <returns>설정 후 상태입니다.</returns>
        public abstract SwitchState OnStateChange(SwitchState state);
    }
}
