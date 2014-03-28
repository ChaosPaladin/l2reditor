using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using L2REditor.Engine.Configuration;

namespace L2REditor {
	public partial class EncodingForm : Form {
		private readonly IniFile configFile;
		public EncodingForm(IniFile ini) {
			InitializeComponent();
			configFile = ini;

			encDecEncoding.Text = "UTF-8";

			{ //loading
				var encdec = configFile.IniReadValue("Saved", "EncDecEncoding");
				if (encdec != null && !encdec.Equals(string.Empty))
					try {
						if (!encdec.Equals("ASCII") || !encdec.Equals("UTF-8"))
							encdec = encDecEncoding.Text;
						encDecEncoding.Text = encdec;
					} catch {
						configFile.IniWriteValue("Saved", "EncDecEncoding", "UTF-8");
					}

				var inEnc = configFile.IniReadValue("Saved", "InputEncoding");
				if (inEnc != null && !inEnc.Equals(string.Empty))
					try {
						inputEncoding.Text = inEnc;
					} catch {
						configFile.IniWriteValue("Saved", "InputEncoding", "Windows-1251");
					}

				var outEnc = configFile.IniReadValue("Saved", "OutputEncoding");
				if (outEnc != null && !outEnc.Equals(string.Empty))
					try {
						outputEncoding.Text = outEnc;
					} catch {
						configFile.IniWriteValue("Saved", "OutputEncoding", "Windows-1251");
					}

				var reencEnable = configFile.IniReadValue("Saved", "ReEncodeEnable");
				if(reencEnable != null && !reencEnable.Equals(string.Empty)) 
					try {
						enableReEncode.Checked = reEncode.Enabled = bool.Parse(reencEnable);
					} catch {
						configFile.IniWriteValue("Saved", "ReEncodeEnable", bool.FalseString);
					}

				var reEnc = configFile.IniReadValue("Saved", "ReEncode");
				if (reEnc != null && !reEnc.Equals(string.Empty))
					try {
						reEncode.Text = reEnc;
					} catch {
						configFile.IniWriteValue("Saved", "ReEncode", "Windows-1251");
					}
			}

			{ //local configure
				bEncDecASCII = encDecEncoding.Text.Equals("ASCII");
				sInputEncoding = inputEncoding.Text;
				sOutputEncoding = outputEncoding.Text;
				bReEncEnable = enableReEncode.Checked;
				sReEncEncoding = reEncode.Text;
				isValidData = true;
			}
		}

		private void EncodingForm_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}

		private void enableReEncode_CheckedChanged(object sender, EventArgs e) {
			bReEncEnable = reEncode.Enabled = enableReEncode.Checked;
			configFile.IniWriteValue("Saved", "ReEncodeEnable", enableReEncode.Checked.ToString());
		}

		private void encDecEncoding_SelectedIndexChanged(object sender, EventArgs e) {
			bEncDecASCII = encDecEncoding.Text.Equals("ASCII");
			configFile.IniWriteValue("Saved", "EncDecEncoding", encDecEncoding.Text);
		}

		private void encoding_TextChanged(object sender, EventArgs e) {
			var tb = (ComboBox) sender;
			try {
				Encoding.GetEncoding(tb.Text);
				if (tb.BackColor == Color.LightCoral)
					tb.BackColor = Color.White;

				findAndSet((ComboBox)sender);
				isValidData = true;
			} catch {
				tb.BackColor = Color.LightCoral;
				isValidData = false;
			}
		}

		private void findAndSet(ComboBox tb) {
			if (tb.Name.Equals("inputEncoding")) {
				sInputEncoding = tb.Text;
				configFile.IniWriteValue("Saved", "InputEncoding", sInputEncoding);
			} else if (tb.Name.Equals("outputEncoding")) {
				sOutputEncoding = tb.Text;
				configFile.IniWriteValue("Saved", "OutputEncoding", sOutputEncoding);
			} else if (tb.Name.Equals("reEncode")) {
				sReEncEncoding = tb.Text;
				configFile.IniWriteValue("Saved", "ReEncode", sReEncEncoding);
			}
		}

		public bool isValidData { get; set; }
		public bool bEncDecASCII { get; set; }
		public string sInputEncoding { get; set; }
		public string sOutputEncoding { get; set; }
		public bool bReEncEnable { get; set; }
		public string sReEncEncoding { get; set; }
	}
}
