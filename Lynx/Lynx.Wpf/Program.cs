using Eto.Forms;
using System;

namespace Lynx.Wpf {
    class Program {
        [STAThread]
        public static void Main(string[] args) {
            new LynxApp(Eto.Platforms.Wpf).Run();
        }
    }
}
