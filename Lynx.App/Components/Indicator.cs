using Eto.Drawing;
using Eto.Forms;
using Lynx.Common;
using Lynx.Interface;

namespace Lynx.Components {
    /// <summary>
    /// 인디케이터
    /// </summary>
    public class Indicator : Component, IIndicator {
        readonly TrayIndicator Tray;

        public Indicator() {
            Tray = new();
            Tray.Activated += OnActivated;
        }

        public Image Image { get => Tray.Image; set => Tray.Image = value; }
        public string Title { get => Tray.Title; set => Tray.Title = value; }
        public ContextMenu Menu { get => Tray.Menu; set => Tray.Menu = value; }

        public event EventHandler<EventArgs> Activated;

        public Image GetImage() => Image;
        public Image SetImage(Image image) => Image = image;

        public ContextMenu GetMenu() => Menu;
        public ContextMenu SetMemu(ContextMenu menu) => Menu = menu;

        public string GetTitle() => Title;
        public string SetTitle(string title) => Title = title;

        public void Show() => Tray.Show();
        public void Hide() => Tray.Hide();

        void OnActivated(object sender, EventArgs e) => Activated?.Invoke(this, e);

        protected override void Dispose(bool disposing) {
            if (disposing) {
                Tray?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
