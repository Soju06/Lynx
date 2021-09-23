using Eto.Forms;
using Lynx.Logger;

namespace Lynx.App.Forms.Controls {
    public partial class ProgressBar : Panel {
		public ProgressBar() {
			InitializeComponent();

			new Thread(() => {
                while (true) {
					for (int i = 0; i < 11; i += 2) {
						Application.Instance.Invoke(() => SetValue(i * 10));
						Thread.Sleep(800);
					}
                }
			}) { IsBackground = true }.Start();
		}

        int uiValue = 0, value = 0;

		/// <summary>
		/// 값
		/// </summary>
		public int Value { 
			get => value;
			set => SetValue(value);
		}

		/// <summary>
		/// 값 설정
		/// </summary>
		public void SetValue(int v) {
			value = v;
			if (!Web.Loaded) return;
			try {
				Web.ExecuteScript($"document.getElementById('p').style.width = '{v}%'");
				uiValue = v;
            } catch {
				LynxApp.UILogger?.Log($"script execution failed".CaptureMake(), LoggerStatus.WARN);
            }
        }

		void OnDocumentLoaded(object sender, WebViewLoadedEventArgs e) {
			if (value != uiValue) SetValue(value);
		}
	}
}
