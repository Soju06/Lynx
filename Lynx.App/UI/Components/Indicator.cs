using Eto.Drawing;
using Eto.Forms;
using Lynx.App.UI.Interface;
using Lynx.Common;

namespace Lynx.App.UI.Components {
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
        public IIndicator SetImage(Image image) => this.Return(_ => Image = image);

        public ContextMenu GetMenu() => Menu;
        public IIndicator SetMemu(ContextMenu menu) => this.Return(_ => Menu = menu);

        public string GetTitle() => Title;
        public IIndicator SetTitle(string title) => this.Return(_ => Title = title);

        public IIndicator Show() => this.Return(_ => Tray.Show());
        public IIndicator Hide() => this.Return(_ => Tray.Hide());

        void OnActivated(object sender, EventArgs e) => Activated?.Invoke(this, e);

        protected override void Dispose(bool disposing) {
            if (disposing) {
                Tray?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
