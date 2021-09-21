using System;
using Eto.Forms;
using Eto.Drawing;

namespace Lynx.App.Forms {
	partial class UpdateUI : Form {
		void InitializeComponent() {
			Title = "My Eto Form";
			Size = new Size(580, 360);
			BackgroundColor = Color.FromArgb(24, 25, 38);
			Resizable = false;

			Content = new TableLayout() {
				Padding = 10,
				Size = Size,
				Rows = {
					new DynamicLayout() {
						Size = new Size(Size.Width, 64),
                    }.Return(x => x.AddCentered(
						new TableRow(
							new ImageView() {
								Image = new Bitmap(@"R:\Downloads\lynx_icon.png"),
								Size = new Size(64, 64)
							},
							new DynamicLayout() {
								Size = new(-1, 64)
							}.Return(w => w.AddCentered(new Label() {
								Text = "Lynx App  ",
								Font = new Font(SystemFonts.Bold().Family, 28, FontStyle.Bold),
								TextColor = Color.FromArgb(255, 255, 255)
							}))
						)
					)),
					new TableRow(new Controls.ProgressBar() {
						Size = new(-1, 40),
					}),
					new TableRow(new TableCell(), "Please login:"),
				}
			};
		}

        protected override void OnSizeChanged(EventArgs e) {
			Content.Size = Size;
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
