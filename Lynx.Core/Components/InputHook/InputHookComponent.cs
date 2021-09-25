using Lynx.Common.Components;
using Lynx.Common.Interface;
using Lynx.Core.Components.InputHook;
using Lynx.Core.Components.Interface;
using Lynx.Logger;
using Lynx.Logger.Attribute;
using Lynx.Logger.Interface;

namespace Lynx.Core.Components {
    public class InputHookComponent : SwitchableComponent, IInputHookComponent, ILoggableComponent {
        IInputHookerComponentBase inputHooker;

        public override bool CanStop { get; } = true;

        public override bool CanPause { get; } = true;

        public override SwitchState OnStateChange(SwitchState state) {
            SetChildComponentState(state);
            return state;
        }

        public IInputHookerComponentBase GetInputHooker() => inputHooker;

        public IInputHookerComponentBase SetInputHooker(IInputHookerComponentBase inputHooker) {
            if (inputHooker == null) throw new ArgumentNullException(nameof(inputHooker));
            Components.Remove(this.inputHooker);
            Components.Add(this.inputHooker = inputHooker);
            inputHooker.KeyboardModel = KeyboardModel;
            this.AppendLogger(inputHooker);
            inputHooker.SetState(SwitchState.Running);
            Logger.Log($"input hooker set {inputHooker.GetType().Name}");
            return inputHooker;
        }

        bool isInited;

        public void OnLoggerInited(ILogger logger) {
            if (isInited) return;
            isInited = true;
            KeyboardModel.KeyDown += (a, b) => {
                Logger.Log($"KeyDown: {a} oldStatus: {b}");
                return true;
            };
            KeyboardModel.KeyUp += (a, b) => {
                Logger.Log($"KeyUp: {a} oldStatus: {b}");
                return true;
            };
            KeyboardModel.KeyStatusChanged += (a, b, c) => {
                Logger.Log($"KeyStatusChanged: {a} oldStatus: {b} nowStatus: {c}");
            };
            if (LynxPlatform.IsWindows) InputHooker = new WindowsInputHooker();
        }

        protected override void Dispose(bool disposing) {
            if(!disposedValue) {
                if(disposing) {
                    Components.DisposeAll();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 인풋 후커
        /// </summary>
        public IInputHookerComponentBase InputHooker { get => inputHooker; set => SetInputHooker(value); }

        public KeyboardModel KeyboardModel { get; private set; } = new();

        [LoggerName("InputHook")]
        public ILogger Logger { get; set; }
    }
}
