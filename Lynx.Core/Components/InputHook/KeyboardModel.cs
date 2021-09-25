namespace Lynx.Core.Components.InputHook {
    /// <summary>
    /// 키보드 모델
    /// </summary>
    public class KeyboardModel : MarshalByRefObject {
        readonly Dictionary<LynxKeys, bool> Keys = new();

        /// <summary>
        /// 키가 입력될때 발생합니다.
        /// </summary>
        public event KeyboardModelKeyDown KeyDown;
        /// <summary>
        /// 키가 떼어질때 발생합니다.
        /// </summary>
        public event KeyboardModelKeyUp KeyUp;

        /// <summary>
        /// 상태가 변경될때 발생합니다. (비동기)
        /// </summary>
        public event KeyboardModelKeyStatusChanged KeyStatusChanged;

        public KeyboardModel() {
            foreach (var item in Enum.GetValues<LynxKeys>())
                Keys.Add(item, false);
        }

        /// <summary>
        /// 상태를 설정합니다.
        /// </summary>
        public bool SetStatus(LynxKeys key, bool isDown) {
            if (key == 0) return true;
            var oldState = Keys[key];
            if (oldState != isDown) Keys[key] = isDown;
            var ig = isDown ? KeyDown?.Invoke(key, oldState) == true 
                : KeyUp?.Invoke(key, oldState) == true;
            Task.Factory.StartNew(() => KeyStatusChanged(key, oldState, isDown));
            return ig;
        }
    }

    public delegate bool KeyboardModelKeyDown(LynxKeys key, bool oldState);
    public delegate bool KeyboardModelKeyUp(LynxKeys key, bool oldState);
    public delegate void KeyboardModelKeyStatusChanged(LynxKeys key, bool oldState, bool nowState);
}
