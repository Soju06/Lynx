namespace Lynx.Mac {
    class Program {
        [STAThread]
        public static void Main() {
            new LynxApp(Eto.Platforms.Mac64).Run();
        }
    }
}
