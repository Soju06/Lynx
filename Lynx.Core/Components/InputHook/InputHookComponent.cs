using Lynx.Common.Components;
using Lynx.Common.Interface;
using Lynx.Core.Components.InputHook.Base;
using Lynx.Core.Components.InputHook.Interface;

namespace Lynx.Core.Components {
    public class InputHookComponent : SwitchableComponent, IInputHookComponent {
        IInputHookerComponentBase inputHooker;

        public override bool CanStop { get; } = true;

        public override bool CanPause { get; } = true;

        public override SwitchState OnStateChange(SwitchState state) {
            if (inputHooker != null) inputHooker.SetState(state);
            return state;
        }

        public IInputHookerComponentBase GetInputHooker() => inputHooker;

        public IInputHookerComponentBase SetInputHooker(IInputHookerComponentBase inputHooker) {
            if (inputHooker == null) throw new ArgumentNullException(nameof(inputHooker));
            Components.Remove(this.inputHooker);
            Components.Add(this.inputHooker = inputHooker);
            return inputHooker;
        }

        /// <summary>
        /// 인풋 후커
        /// </summary>
        public IInputHookerComponentBase InputHooker { get => inputHooker; set => SetInputHooker(value); }
    }
}
