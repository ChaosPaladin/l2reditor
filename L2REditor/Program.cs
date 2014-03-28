using System;
using System.IO;
using System.Windows.Forms;

namespace L2REditor {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			if (!File.Exists(@".\l2asm.exe") || !File.Exists(@".\l2disasm.exe") || !File.Exists(@".\l2encdec.exe")) {
				MessageBox.Show("Corrupted resources!", "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (!File.Exists(@".\dat.ini")) {
				File.Create(@".\dat.ini").Close();
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
