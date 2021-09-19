namespace Lynx.Wpf {
    class Program {
        [STAThread]
        public static void Main() {
            new LynxApplication(Eto.Platforms.Wpf).Run();
        }
    }
}
