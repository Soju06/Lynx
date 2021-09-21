using Eto.Drawing;
using Eto.Forms;
using Lynx.Logger;

namespace Lynx.App.Forms.Controls {
    partial class ProgressBar : Panel {
		WebView Web;

		void InitializeComponent() {
			Size = new Size(416, 52);
			BackgroundColor = Color.FromArgb(255,255,255);

			Content = Web = new WebView() { 
				BackgroundColor = BackgroundColor
			}.Return(x => {
				x.DocumentLoaded += OnDocumentLoaded;
				x.LoadHtml(Resources.Web.ProgressBar);
			});
		}

        protected override void OnSizeChanged(EventArgs e) {
			if (Web.Size != Size)
				Web.Size = Size;
            base.OnSizeChanged(e);
        }
    }
}
