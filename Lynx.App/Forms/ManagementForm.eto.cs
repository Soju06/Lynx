using System;
using Eto.Forms;
using Eto.Drawing;
using Lynx.Common;

namespace Lynx.App.Forms {
	partial class ManagementForm : Form {
		void InitializeComponent() {
			const int padding = 4;

			Title = LynxEnvironment.LynxName;
			MinimumSize = new Size(560, 420);
			BackgroundColor = Color.FromArgb(25, 25, 25);
			Padding = padding;
			Content = new StackLayout {
				Items = {
					new WebView() {
						Size = new(1224 - (padding * 2), 720 - (padding * 2)),
						Url = new Uri("https://google.com/")
                    }
				}
			};
			Menu = new MenuBar { 
				Items = {

				},
				QuitItem = new Command {
					MenuText = "Quit",
					Shortcut = Application.Instance.CommonModifier | Keys.Q 
				}
			};
		}
	}
}
