using Eto.Drawing;
using Eto.Forms;

namespace Lynx {
    partial class MainForm : Form {
        void InitializeComponent() {
            Title = "My Eto Form";
            MinimumSize = new Size(200, 200);
            Padding = 10;

            Content = new StackLayout
            {
                Items =
                {
                    "Hello World!",
                }
            };
            
        }
    }
}
