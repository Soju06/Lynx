using System;
using Eto.Forms;
using Eto.Drawing;

namespace Lynx.App.Forms {
	partial class ManagementUI : Form {
		WebView Web;

		void InitializeComponent() {
			const int padding = 0;
			
			Title = "Lynx";
			MinimumSize = new Size(560, 420);
			BackgroundColor = Color.FromArgb(25, 25, 25);
			Size = new Size(1270, 720);
			Padding = padding;
			Content = new StackLayout {
				Items = {
					(Web = new WebView() {
						Size = Size - new Size(padding * 2, padding * 2),
                    })
				}
			};
			Menu = new MenuBar { 
				Items = {
					new Command((_, __) => new UpdateUI().Show()) {
						MenuText = "Open Updater"
                    }
				},
				QuitItem = new Command((_, __) => Close()) {
					MenuText = "Quit",
					Shortcut = Application.Instance.CommonModifier | Keys.Q
				}
			};
		}

        protected override void OnSizeChanged(EventArgs e) {
			Web.Size = Size;
            base.OnSizeChanged(e); 
        }
    }
}
