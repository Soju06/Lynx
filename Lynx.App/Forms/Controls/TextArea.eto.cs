using System;
using Eto.Forms;
using Eto.Drawing;

namespace Lynx.App.Forms.Controls {
	partial class TextArea : Panel {
		WebView Web;

		void InitializeComponent() {
			Size = new Size(582, 334);
			Content = Web = new WebView() {
				BackgroundColor = BackgroundColor,
				Size = Size
			}.Return(x => {
				x.DocumentLoaded += OnDocumentLoaded;
				x.LoadHtml(Resources.Web.TextArea);
			});
		}

        protected override void OnSizeChanged(EventArgs e) {
			if (Size != Web.Size) Web.Size = Size;
            base.OnSizeChanged(e);
        }
    }

	static class ILovePython_TMP {
		public static T Return<T>(this T t, Action<T> func) {
			func.Invoke(t);
			return t;
		}
	}
}
