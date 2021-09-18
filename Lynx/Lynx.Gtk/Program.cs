using Eto.Forms;
using System;

namespace Lynx.Gtk {
    class Program {
        [STAThread]
        public static void Main(string[] args) {
            new LynxApp(Eto.Platforms.Gtk).Run();
        }
    }
}
