namespace Lynx.Gtk {
    class Program {
        [STAThread]
        public static void Main() =>
            new LynxApplication(Eto.Platforms.Gtk).Run();
    }
}
