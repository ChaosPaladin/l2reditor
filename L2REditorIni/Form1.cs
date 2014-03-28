using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using L2REditor.Engine.Configuration;
using L2REditor.Engine.Crypt;
using L2REditor.Engine.GUI;

namespace L2REditorIni {
	public partial class Form1 : Form {
		private readonly DebugForm debugf;
		private readonly Crypt crypt;
		private readonly IniFile config;

		private bool isSaved = true;
		private string encdecVersion;
		private string openedFile;

		private readonly Dictionary<TreeNode, string> treeValues1 = new Dictionary<TreeNode, string>();

		public Form1() {
			InitializeComponent();

			debugf = GUIFactory.createDebugForm();

			debugf.write("Init controlls...");
			loadingCircle.UseWaitCursor = true;
			loadingCircle.Active = false;
			loadingCircle.Size = Size;
			loadingCircle.Dock = DockStyle.Fill;
			loadingCircle.NumberSpoke = 30;
			loadingCircle.InnerCircleRadius = 40;
			loadingCircle.OuterCircleRadius = 60;
			loadingCircle.RotationSpeed = 90;
			loadingCircle.SpokeThickness = 4;

			debugf.write("Init configure...");
			if (!File.Exists(@".\inieditor.ini"))
				File.Create(@".\inieditor.ini");

			config = new IniFile(@".\inieditor.ini");
			var makeBackup = config.IniReadValue("Saved", "MakeBackup");
			if (makeBackup == null || makeBackup.Equals(string.Empty)) {
				makeBackup = makeBackupButton.Checked.ToString();
				config.IniWriteValue("Saved", "MakeBackup", makeBackup);
			}
			else try {
					makeBackupButton.Checked = bool.Parse(makeBackup);
				} catch {
					config.IniWriteValue("Saved", "MakeBackup", bool.TrueString);
				}

			debugf.write("Init crypt engine...");
			try {
				crypt = new Crypt(false);
			} catch {
				if(MessageBox.Show(this, "Corrupted resources!", "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
					Environment.Exit(1);
			}
		}

		private string createTempFile() {
			var file = Path.GetRandomFileName();
			file = Path.Combine(Path.GetTempPath(), file);
			return file;
		}

		private void enableLoading() {
			if (loadingCircle.Visible)
				return;
//			invisElements();
			loadingCircle.Visible = true;
			loadingCircle.Active = true;
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void disableLoading() {
			if (!loadingCircle.Visible)
				return;
//			visElements();
			loadingCircle.Active = false;
			loadingCircle.Visible = false;
			FormBorderStyle = FormBorderStyle.Sizable;
		}

		private void outputMenu_Click(object sender, EventArgs e) {
			if (debugf.isVisible()) {
				debugf.focus();
				return;
			}
			debugf.show();
		}

		private void openButton_Click(object sender, EventArgs e) {
			if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
				return;

			enableLoading();
			closeMenu_Click(null, null);
			new Thread(openFile).Start();
		}

		private void saveMenu_Click(object sender, EventArgs e) {

		}

		private void saveAsMenu_Click(object sender, EventArgs e) {

		}

		private void closeMenu_Click(object sender, EventArgs e) {
			sectionsTree.Nodes.Clear();
		}

		private void makeBackupButton_Click(object sender, EventArgs e) {
			makeBackupButton.Checked = !makeBackupButton.Checked;
			config.IniWriteValue("Saved", "MakeBackup", makeBackupButton.Checked.ToString());
		}

		private void chaneIpButton_Click(object sender, EventArgs e) {

		}

		private void devModeButton_Click(object sender, EventArgs e) {

		}

		private void changeLangButton_Click(object sender, EventArgs e) {

		}

		private void changeWindowButton_Click(object sender, EventArgs e) {

		}

		private void sectionsTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			try {
				textBox1.Text = treeValues1[e.Node];
			} catch {}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			var selected = sectionsTree.SelectedNode;
			if (selected == null) return;
			if (treeValues1.ContainsKey(selected)) {
				//var old = treeValues1[selected];
				treeValues1[selected] = textBox1.Text;
				//treeValues2.Remove(old);
				//treeValues2.Add(textBox1.Text, selected);
			}
		}

		private void Form1_ResizeEnd(object sender, EventArgs e) {
			loadingCircle.Size = Size;
		}

		private void openFile() {
			openedFile = openFileDialog1.FileName;

			try {
				encdecVersion = crypt.getCryptVersion(openedFile);
			} catch {
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed parse crypt version");
					MessageBox.Show(this, "Failed parse crypt version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}));
				return;
			}

			var originalFile = createTempFile();
			var decFile = createTempFile();

			File.Copy(openedFile, originalFile);

			if (!crypt.decryptFile(originalFile, decFile, encdecVersion)) {
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed decrypt file");
					MessageBox.Show(this, "Failed decrypt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}));
			}

			loadFileIni(decFile);
		}

		private void loadFileIni(string file) {
			string[] lines = File.ReadAllLines(file);

			TreeNode rootNode = null;
			foreach (var line in lines) {
				if (line.Equals(string.Empty))
					continue;

				bool commented = line.StartsWith(";");

				if (line.StartsWith("[") || (commented && line.StartsWith(";[")) && line.Contains("]")) { //section
					var name = String.Format("{0}{1}", commented ? ";" : string.Empty, line.Substring(line.IndexOf('[') + 1, line.LastIndexOf(']') - 1));
					var node = new TreeNode(name) {
						Name = name
					};
					Invoke(new ThreadStart(() => sectionsTree.Nodes.Add(node)));
					rootNode = node;
				} else if (rootNode == null)
					continue;

				if (line.Contains("=")) { //prorety=value
					var splitInx = line.IndexOf('=');
					var property = line.Substring(0, splitInx);
					var value = line.Substring(splitInx + 1);

					var node = new TreeNode(property) {
						Name = property
					};

					var root = rootNode;
					Invoke(new ThreadStart(() => root.Nodes.Add(node)));
					treeValues1.Add(node, value);
					//treeValues2.Add(value, node);
				}
			}

			Invoke(new ThreadStart(disableLoading));
		}
		
	}
}
