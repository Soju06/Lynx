using Eto.Forms;
using Lynx.Logger;

namespace Lynx.App.Forms.Controls {
    public partial class TextArea : Panel {
		string text, uiText;
		bool _readonly, uiReadonly;

		public TextArea() {
			InitializeComponent();
			SetReadOnly(true);
			WriteForce("hello");
			WriteForce("world");
		}

		/// <summary>
		/// ≈ÿΩ∫∆Æ
		/// </summary>
		public string Text { 
			get => text;
			set => SetText(value);
		}

		public bool ReadOnly {
			get => _readonly;
			set => SetReadOnly(value);
		}

		public void SetText(string s) {
			text = s;
			if (!Web.Loaded) return;
			try {
				Web.ExecuteScript($"document.getElementById('a').value = '{s.Replace("'", "\\'")}'");
				uiText = s;
            } catch {
				LynxApp.UILogger?.Log($"script execution failed".CaptureMake(), LoggerStatus.WARN);
            }
        }

		string writeForceBuffer = "";
		
		public void WriteForce(string s) {
			s += "\\r\\n";
			if (!Web.Loaded) {
				writeForceBuffer += s;
				return;
			}
			var e = s;
			try {
				Web.ExecuteScript(
					$"var x = document.getElementById('a');" +
					$"x.value += '{(writeForceBuffer.Length > 0 ? writeForceBuffer.Replace("'", "\\'") + "\\r\\n" : null)}{(s?.Replace("'", "\\'"))}';" +
					 "x.scrollTop = x.scrollHeight;");
				writeForceBuffer = e = null;
            } catch {
				LynxApp.UILogger?.Log($"script execution failed".CaptureMake(), LoggerStatus.WARN);
            }
			writeForceBuffer += e;
        }

		public void SetReadOnly(bool r) {
			_readonly = r;
			if (!Web.Loaded) return;
			try {
				Web.ExecuteScript($"document.getElementById('a').readOnly = '{r}'");
				uiReadonly = r;
            } catch {
				LynxApp.UILogger?.Log($"script execution failed".CaptureMake(), LoggerStatus.WARN);
            }
		}

		void OnDocumentLoaded(object sender, WebViewLoadedEventArgs e) {
			if (text != uiText) SetText(text);
			if (_readonly != uiReadonly) SetReadOnly(_readonly);
			if (writeForceBuffer.Length > 0) WriteForce(null);
		}
	}
}
