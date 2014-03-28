using System;
using System.Threading;
using System.Windows.Forms;

namespace L2REditor.Engine.GUI {
	partial class Debugf : Form, DebugForm {
		public Debugf() {
			InitializeComponent();
		}

		private void Debugf_FormClosing(object sender, FormClosingEventArgs e) {
			Hide();
			e.Cancel = true;
		}

		public void write(string text) {
			if (textBox1.Lines.Length > 100) {
				textBox1.Text = "";
				new Thread(new ThreadStart(delegate {
					Thread.Sleep(5000);
					GC.Collect();
				})).Start();
			}
			textBox1.Text += String.Format("{0}\r\n", text);
		}

		public void show() {
			Show();
			Focus();
		}

		public void focus() {
			Focus();
		}

		public void hide() {
			Hide();
		}

		public bool isVisible() {
			return Visible;
		}
	}
}
