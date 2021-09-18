using Lynx.Common;
using Lynx.Common.Components;
using Lynx.Common.Interface;
using System;

namespace Lynx.Core {
    /// <summary>
    /// lynx 코어 
    /// </summary>
    public class LynxCore : SwitchableComponent {
        public LynxCore() {

        }

        public override bool CanStop { get; } = true;

        public override bool CanPause { get; } = true;

        public override SwitchState OnStateChange(SwitchState State) {

            return State;
        }
    }
}
