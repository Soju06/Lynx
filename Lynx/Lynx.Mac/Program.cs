using System;

namespace Lynx.Mac {
    class Program {
        [STAThread]
        public static void Main(string[] args) {
            new LynxApp(Eto.Platforms.Mac64).Run();
        }
    }
}
