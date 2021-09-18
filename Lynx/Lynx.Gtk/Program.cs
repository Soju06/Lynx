namespace Lynx.Gtk {
    class Program {
        [STAThread]
        public static void Main() {
            new LynxApp(Eto.Platforms.Gtk).Run();
        }
    }
}
