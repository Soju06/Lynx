namespace Lynx.Mac {
    class Program {
        [STAThread]
        public static void Main() =>
            new LynxApplication(Eto.Platforms.Mac64).Run();
    }
}
