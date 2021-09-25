using Eto.Forms;
using Eto.Drawing;

namespace Lynx.App.Forms {
    partial class UpdateUI : Form {
		Controls.TextArea TextArea;
		int src_a, src_b;

		void InitializeComponent() {
			Title = "Lynx Update";
			Size = new Size(526, 360);
			BackgroundColor = Color.FromArgb(24, 25, 38);
			Resizable = false;
			Maximizable = false;

			Content = new TableLayout() {
				Size = new Size(526, src_a = 360),
				Rows = {
					new DynamicLayout() {
						Size = new Size(-1, 64 + 10)
					}.Return(x => x.AddCentered(
						new TableRow(
							new ImageView() {
								Image = new Bitmap(Resources.App.LynxIcon),
								Size = new Size(64, 64)
							},
							new DynamicLayout() {
								Size = new(-1, 64)
							}.Return(w => w.AddCentered(new Label() {
								Text = "Lynx App",
								Font = new Font(SystemFonts.Bold().Family, 28, FontStyle.Bold),
								TextColor = Color.FromArgb(255, 255, 255)
							}))
						)
					)),
					new DynamicLayout() {
						Padding = new(22, 0)
					}.Return(x => {
						x.Add(new Label() {
							Text = "0% - Initializing...",
							Font = SystemFonts.Bold(),
							TextColor = Color.FromArgb(210, 210, 210)
						});
						x.BeginVertical(new(0, 6));
						x.Add(TextArea = new Controls.TextArea() { 
							Size = new(-1, src_b = 188)
						});
					}),
					new DynamicLayout() {
						Padding = new(20, 0)
                    }.Return(x => {
						x.Add(new Controls.ProgressBar() {
							Size = new(-1, 16)
						});
					}),
					new DynamicLayout() {
						Padding = new Padding(15, 10)
					}.Return(x => {
						x.BeginHorizontal();
						x.Add(null);
						x.AddCentered(new Button() {
									Text = "Cancel",
									Size = new(64, 30),
									TextColor = Color.FromArgb(200, 200, 200),
									BackgroundColor = Color.FromArgb(24, 25, 38)
								}, spacing: new(2, 0));
						x.AddCentered(new Button() {
									Text = "Close",
									Size = new(64, 30),
									TextColor = Color.FromArgb(200, 200, 200),
									BackgroundColor = Color.FromArgb(58, 113, 193)
								}, spacing: new(2, 0));
					}), null
				}
			};
            Content.SizeChanged += OnContentSizeChanged;
			OnSizeChanged(EventArgs.Empty);
		}

        private void OnContentSizeChanged(object sender, EventArgs e) {
			var t_h = Content.Size.Height - (src_a - src_b);
			if (t_h > 1) TextArea.Size = new(-1, t_h);
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
