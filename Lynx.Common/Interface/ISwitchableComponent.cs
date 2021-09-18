using Lynx.Common.Components;

namespace Lynx.Common.Interface {
    /// <summary>
    /// 스위치 가능한
    /// </summary>
    public interface ISwitchableComponent : IComponent {
        /// <summary>
        /// 멈출수 있는
        /// </summary>
        public bool CanStop { get; }
        /// <summary>
        /// 일시 정지 가능한
        /// </summary>
        public bool CanPause { get; }

        /// <summary>
        /// 현재 상태입니다.
        /// </summary>
        public SwitchState State { get; }

        /// <summary>
        /// 현재 상태입니다.
        /// </summary>
        public SwitchState GetState();

        /// <summary>
        /// 설정을 변경합니다.
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public bool SetState(SwitchState State);

        /// <summary>
        /// 정지
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool Stop();
        /// <summary>
        /// 일시 정지
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool Pause();
        /// <summary>
        /// 재개
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool Resume();
    }

    /// <summary>
    /// 스위치 상태
    /// </summary>
    public enum SwitchState {
        /// <summary>
        /// 작동되지 않음
        /// </summary>
        Idle = 0,
        /// <summary>
        /// 작동중
        /// </summary>
        Running = 1,
        /// <summary>
        /// 일시 정지
        /// </summary>
        Paused = 2,
        /// <summary>
        /// 중지
        /// </summary>
        Stoped = 3
    }
}
