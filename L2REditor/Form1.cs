using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using L2REditor.Engine;
using L2REditor.Engine.Configuration;
using L2REditor.Engine.Crypt;
using L2REditor.Engine.GUI;

namespace L2REditor {
	partial class Form1 : Form {
		private readonly DebugForm debugf;
		private readonly EncodingForm encodingf;

		private ToolStripMenuItem checkedButtonVer;

		private readonly Crypt crypt;

		private string encdecVersion;
		private string opFile;
		private DDF dataDefinesFile;

		private string clipboard;

		private bool isSaved = true;

		private readonly IniFile configFile;

		private DataGridViewCell[] colored;

//		private readonly Mutex mutex;

		private readonly Bitmap[] imagesDrag = {
			Properties.Resources._1,
			Properties.Resources._2,
			Properties.Resources._3,
			Properties.Resources._4,
			Properties.Resources._5,
			Properties.Resources._6
		};
		private readonly Random rnd = new Random();

		public Form1() {
			InitializeComponent();

			debugf = GUIFactory.createDebugForm();

			crypt = new Crypt();

//			mutex = new Mutex();

			debugf.write("Configure controls...");
			loadingCircle.UseWaitCursor = true;
			loadingCircle.Active = false;
			loadingCircle.Size = Size;
			loadingCircle.Dock = DockStyle.Fill;
			loadingCircle.NumberSpoke = 30;
			loadingCircle.InnerCircleRadius = 40;
			loadingCircle.OuterCircleRadius = 60;
			loadingCircle.RotationSpeed = 90;
			loadingCircle.SpokeThickness = 4;

			debugf.write("Restore lastets use...");
			configFile = new IniFile(@".\dat.ini");
			string ver = configFile.IniReadValue("Saved", "SelectedVersion");
			if (ver != null && !ver.Equals(string.Empty)) {
				crypt.version = CVersion.getVersionFromText(ver);

				switch (crypt.version) {
					case CVersion.EVersion.C3:
						checkedButtonVer = c3Button;
						break;
					case CVersion.EVersion.C4:
						checkedButtonVer = c4Button;
						break;
					case CVersion.EVersion.C5:
						checkedButtonVer = c5Button;
						break;
					case CVersion.EVersion.Interlude:
						checkedButtonVer = c6Button;
						break;
					case CVersion.EVersion.CT10:
						checkedButtonVer = ct10Button;
						break;
					case CVersion.EVersion.CT15:
						checkedButtonVer = ct15Button;
						break;
					case CVersion.EVersion.CT21:
						checkedButtonVer = ct21Button;
						break;
					case CVersion.EVersion.CT22en:
						checkedButtonVer = ct22Button;
						break;
					case CVersion.EVersion.CT22ru:
						checkedButtonVer = ct22ruButton;
						break;
					case CVersion.EVersion.CT23en:
						checkedButtonVer = ct23Button;
						break;
					case CVersion.EVersion.CT23kr:
						checkedButtonVer = ct23krButton;
						break;
					case CVersion.EVersion.CT23ru:
						checkedButtonVer = ct23ruButton;
						break;
					case CVersion.EVersion.CT24en:
						checkedButtonVer = ct24Button;
						break;
					case CVersion.EVersion.CT24ru:
						checkedButtonVer = ct24ruButton;
						break;
					case CVersion.EVersion.CT25en:
						checkedButtonVer = ct25Button;
						break;
					case CVersion.EVersion.CT26en:
						checkedButtonVer = ct26Button;
						break;
					case CVersion.EVersion.CT31:
						checkedButtonVer = ct31Button;
						break;
					case CVersion.EVersion.CT32:
						checkedButtonVer = ct32Button;
						break;
					case CVersion.EVersion.CT33:
						checkedButtonVer = ct33Button;
						break;
				}

				checkedButtonVer.Checked = true;
			}

			var lastFile = configFile.IniReadValue("Saved", "FileName");
			if (lastFile != null && !lastFile.Equals(string.Empty)) {
				openFileDialog1.FileName = lastFile;
			}

			var forceDebug = configFile.IniReadValue("View", "ForceOutput");
			if (forceDebug != null && !forceDebug.Equals(string.Empty)) {
				bool force;
				try {
					force = bool.Parse(forceDebug);
				} catch {
					configFile.IniWriteValue("View", "ForceOutput", bool.FalseString);
					force = false;
				}

				if(force)
					debugf.show();
			} else configFile.IniWriteValue("View", "ForceOutput", bool.FalseString);

			encodingf = new EncodingForm(configFile);
		}



		//inner circle
		private void enableLoading() {
			if (loadingCircle.Visible) return;
			invisElements();
			loadingCircle.Visible = true;
			loadingCircle.Active = true;
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void disableLoading() {
			if (!loadingCircle.Visible) return;
			visElements();
			loadingCircle.Active = false;
			loadingCircle.Visible = false;
			FormBorderStyle = FormBorderStyle.Sizable;
		}

		private void invisElements() {
			dataTable.Visible = false;
			preEditor.Visible = false;
			openEditorButton.Visible = false;
		}

		private void visElements() {
			dataTable.Visible = true;
			preEditor.Visible = true;
			openEditorButton.Visible = true;
		}








		//events
		private void openFile_Click(object sender, EventArgs e) {
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			closeButton_Click(null, null);

			saveFileDialog1.FileName = Path.GetFileName(openFileDialog1.SafeFileName);

			new Thread(handleFile).Start(openFileDialog1.FileName);
		}

		private void saveButton_Click(object sender, EventArgs e) {
			new Thread(processSave).Start(opFile);
		}

		private void saveAsButton_Click(object sender, EventArgs e) {
			if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
				return;

			new Thread(processSave).Start(saveFileDialog1.FileName);
		}

		private void closeButton_Click(object sender, EventArgs e) {
			if (!isSaved) {
				if (MessageBox.Show(this, "Save your changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.Yes) {
					new Thread(processSave).Start(opFile);
				}
			}

//			mutex.WaitOne(); //wait ex all operations
			debugf.write("Unload table...");
			opFile = null;
			File.Delete(dataDefinesFile.eDDF); //del garbage
			dataDefinesFile = null;
			clipboard = null;
			colored = null;
			dataTable.Rows.Clear();
			dataTable.Columns.Clear();
			findType.Items.Clear();
			isSaved = true;
//			mutex.ReleaseMutex();

			new Thread(new ThreadStart(delegate { //free resources
				Thread.Sleep(5000);
				GC.Collect();
			})).Start();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			closeButton_Click(null, null); //we must del garbage
		}

		private void debugButton_Click(object sender, EventArgs e) {
			if (debugf.isVisible()) {
				debugf.focus();
				return;
			}
			debugf.show();
		}

		private void versionSelect_Click(object sender, EventArgs e) {
			if (checkedButtonVer != null)
				checkedButtonVer.Checked = !checkedButtonVer.Checked;
			checkedButtonVer = (ToolStripMenuItem)sender;
			crypt.version = CVersion.getVersionFromText(((ToolStripMenuItem)sender).Text);
			debugf.write(String.Format("Selected: {0}", CVersion.getName(crypt.version)));
			configFile.IniWriteValue("Saved", "SelectedVersion", ((ToolStripMenuItem)sender).Text);
		}

		private void Form1_ResizeEnd(object sender, EventArgs e) {
			loadingCircle.Size = Size;
		}

		private void preEditor_TextChanged(object sender, EventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;
			dataTable.SelectedCells[0].Value = preEditor.Text;
			isSaved = false;
		}

		private void dataTable_CellSelect(object sender, DataGridViewCellEventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;
			preEditor.Text = (string)dataTable.SelectedCells[0].Value;
			rowSelectId.Text = dataTable.SelectedCells[0].RowIndex.ToString();
			columnSelectId.Text = dataTable.SelectedCells[0].ColumnIndex.ToString();
		}

		private void table_deleteButton_Click(object sender, EventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;
			foreach (DataGridViewRow row in dataTable.SelectedRows) {
				dataTable.Rows.RemoveAt(row.Index);
			}
		}

		private void table_addBeforeButton_Click(object sender, EventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;
			dataTable.Rows.Insert(dataTable.SelectedRows[0].Index, new DataGridViewRow());
			isSaved = false;
		}

		private void table_addAfterButton_Click(object sender, EventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;

			try {
				var row = dataTable.Rows[dataTable.SelectedRows[0].Index + 1];
				dataTable.Rows.Insert(row.Index, new DataGridViewRow());
			} catch {
				dataTable.Rows.Add(new DataGridViewRow());
			}

			isSaved = false;
		}

		private void table_clearButton_Click(object sender, EventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;
			for (int i = 0; i < dataTable.SelectedCells.Count; i++)
				dataTable.SelectedCells[i].Value = string.Empty;
			isSaved = false;
		}

		private void table_rowMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				dataTable.Rows[e.RowIndex].Selected = true;
				columnMenu.Show(MousePosition.X, MousePosition.Y);
			}
		}

		private void table_sortCompare(object sender, DataGridViewSortCompareEventArgs e) {
			try {
				var val1 = Decimal.Parse((string)e.CellValue1);
				var val2 = Decimal.Parse((string)e.CellValue2);
				e.SortResult = val1.CompareTo(val2);
			} catch {
				var val1 = (string)e.CellValue1;
				var val2 = (string)e.CellValue2;
				e.SortResult = String.Compare(val1, val2, StringComparison.Ordinal);
			}
			e.Handled = true;
		}

		private void menuButtons_MouseHover(object sender, EventArgs e) {
			var button = (ToolStripDropDownButton)sender;
			button.ShowDropDown();
		}

		private void dataTable_KeyDown(object sender, KeyEventArgs e) {
			if (dataTable.SelectedCells.Count < 1)
				return;

			if (e.KeyCode == Keys.Delete) { //delete
				for (int i = 0; i < dataTable.SelectedCells.Count; i++) {
					dataTable.SelectedCells[i].Value = string.Empty;
				}
			} else if (e.Control && e.KeyCode == Keys.C) { //copy
				var sb = new StringBuilder();
				if(colored != null)
					for (int i = 0; i < colored.Length; i++) {
						if(colored[i] == null) continue;
						colored[i].Style.BackColor = DefaultBackColor;
					}
				colored = new DataGridViewCell[dataTable.SelectedCells.Count];
				for (int i = 0; i < dataTable.SelectedCells.Count; i++) {
					sb.AppendFormat("{0}\t", dataTable.SelectedCells[i].Value);
					colored[i] = dataTable.SelectedCells[i];
					colored[i].Style.BackColor = Color.LightBlue;
				}

				//i have a veeeery fucked problem in Clipboard...
				//that have a external exception on setText/setData/etc
				//!!!BUT!!! if i use native functions from user32.dll
				//i dont have a problems so... fucked microsoft and c sharp
				clipboard = sb.ToString();
			} else if (e.Control && e.KeyCode == Keys.V) { //paste
				if (clipboard == null)
					return;

				var data = clipboard.Split('\t');
				for (int i = 0; i < Math.Min(data.Length, dataTable.SelectedCells.Count); i++)
					dataTable.SelectedCells[i].Value = data[i];
			}
		}

		private void dragEnter(object sender, DragEventArgs e) {
			if (loadingCircle.Visible) return;
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Scroll;
				if (!labelDrag.Visible) {
					invisElements();
					labelDrag.Image = imagesDrag[rnd.Next(1, 6)];
					labelDrag.Visible = true;
				}
			} else
				e.Effect = DragDropEffects.None;
		}

		private void dragLeave(object sender, EventArgs e) {
			if (!labelDrag.Visible) 
				return;
			labelDrag.Visible = false;
			if(!loadingCircle.Visible)
				visElements();
		}

		private void dragDrop(object sender, DragEventArgs e) {
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
				return;

			dragLeave(null, null);

			var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			for (int i = 0; i < files.Length; i++) {
				if (!files[i].EndsWith(".dat"))
					continue;
				openFileDialog1.InitialDirectory = Path.GetFullPath(files[i]);
				openFileDialog1.FileName = Path.GetFileName(files[i]);
				saveFileDialog1.FileName = Path.GetFileName(files[i]);
				new Thread(handleFile).Start(files[i]);
				break;
			}
		}

		private void encodingButton_Click(object sender, EventArgs e) {
			if (encodingf.Visible)
				encodingf.Focus();
			else
				encodingf.Show();
		}

		private void jumpToColumn_TextChanged(object sender, EventArgs e) { //search
			if (findType.SelectedItem == null) return;
			if (findType.SelectedItem.Equals("Row id")) {
				int index = -1;
				try {
					index = int.Parse(jumpToColumn.Text);
					// ReSharper disable once EmptyGeneralCatchClause
				} catch {
				}

				if (index < 0 || index >= dataTable.RowCount) {
					jumpToColumn.BackColor = Color.LightCoral;
					return;
				}

				if (jumpToColumn.BackColor == Color.LightCoral)
					jumpToColumn.BackColor = Color.White;

				dataTable.ClearSelection();
				dataTable.Rows[index].Selected = true;
				dataTable.FirstDisplayedScrollingRowIndex = index;
				dataTable_CellSelect(null, null);
			} else {
				DataGridViewColumn reqColumn = null;
				foreach (DataGridViewColumn column in dataTable.Columns)
					if (column.Name.Equals((string) findType.SelectedItem)) {
						reqColumn = column;
						break;
					}

				if (reqColumn == null)
					return;

				foreach (DataGridViewRow row in dataTable.Rows) {
					if (row.Cells[reqColumn.Index].Value == null)
						continue;
					if (((string)row.Cells[reqColumn.Index].Value).StartsWith(jumpToColumn.Text) ||
						((string)row.Cells[reqColumn.Index].Value).Contains(jumpToColumn.Text)) {
						row.Cells[reqColumn.Index].Selected = true;
						dataTable.ClearSelection();
						dataTable.FirstDisplayedCell = row.Cells[reqColumn.Index];
						if (jumpToColumn.BackColor == Color.LightCoral)
							jumpToColumn.BackColor = Color.White;
						dataTable_CellSelect(null, null);
						return;
					}
				}

				jumpToColumn.BackColor = Color.LightCoral;
			}
		}








		//logic
		private void handleFile(object param) {
//			mutex.WaitOne();
			Invoke(new ThreadStart(enableLoading));

			if (!encodingf.isValidData) {
				Invoke(new ThreadStart(delegate {
					debugf.write("Encoding settings is invalid");
					MessageBox.Show(this, "Encoding settings is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			if (crypt.version == CVersion.EVersion.NONE) {
				Invoke(new ThreadStart(delegate {
					debugf.write("ASM version not selected");
					MessageBox.Show(this, "ASM version not selected! Please select ASM version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			opFile = (string)param;

			configFile.IniWriteValue("Saved", "FileName", Path.GetFileName(opFile));

			Invoke(new ThreadStart(() => debugf.write(String.Format("File: {0}", opFile))));

			try {
				encdecVersion = crypt.getCryptVersion(opFile);
			} catch {
				Invoke(new ThreadStart(delegate {
					debugf.write(String.Format("Failed read header from file: \"{0}\"", opFile));
					MessageBox.Show(this, "Failed read file header", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			dataDefinesFile = crypt.getDDF(opFile);
			if (dataDefinesFile == null) {
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("DDF for this file not found!");
					MessageBox.Show(this, "DDF for this file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			string originalFile = IOUtils.getTempFile();
			string decFile = IOUtils.getTempFile();
			File.Copy(opFile, originalFile);

			if (!crypt.decryptFile(originalFile, decFile, encdecVersion)) {
				File.Delete(originalFile);
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed decode file");
					MessageBox.Show(this, "Failed decode file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			string disasmFile = IOUtils.getTempFile();

			if(!crypt.disasmFile(decFile, disasmFile, dataDefinesFile, encodingf.bEncDecASCII)) {
				File.Delete(originalFile);
				File.Delete(decFile);
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed disasm file");
					MessageBox.Show(this, "Failed disasm file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				return;
			}

			File.Delete(originalFile);
			File.Delete(decFile);

			Invoke(new ThreadStart(() => debugf.write(crypt.getOut())));

			var lines = File.ReadAllLines(disasmFile, Encoding.GetEncoding(encodingf.sInputEncoding));

			File.Delete(disasmFile);

			constructTable(lines);

//			mutex.ReleaseMutex();
		}

		private void constructTable(string[] lines) {
			//create colums
			Invoke(new ThreadStart(() => findType.Items.Add("Row id")));

			string[] colums = lines[0].Split('\t');
			var dColums = new DataGridViewTextBoxColumn[colums.Length];
			for (int i = 0; i < colums.Length; i++) {
				dColums[i] = new DataGridViewTextBoxColumn();
				dColums[i].Name = dColums[i].HeaderText = colums[i];
				dColums[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				int i1 = i;
				Invoke(new ThreadStart(() => findType.Items.Add(colums[i1])));
			}

			Invoke(new ThreadStart(delegate {
				dataTable.Columns.AddRange(dColums);
				debugf.write(String.Format("Init {0} colums", dColums.Length));
			}));

			var rows = new DataGridViewRow[lines.Length-1];
			for (int i = 1; i < lines.Length; i++) {
				string[] values = lines[i].Split('\t');
				rows[i - 1] = new DataGridViewRow();
				foreach (var value in values) {
					rows[i - 1].Cells.Add(new DataGridViewTextBoxCell {Value = value});
				}
			}

			Invoke(new ThreadStart(delegate {
				dataTable.Rows.AddRange(rows);
				debugf.write(String.Format("Init {0} rows", rows.Length));
				disableLoading();
			}));
			/* slowly, very slowwww
			for (int i = 1; i < lines.Length; i++) {
				string[] values = lines[i].Split('\t');
				var row = new DataGridViewRow();
				foreach (var value in values) {
					row.Cells.Add(new DataGridViewTextBoxCell {
						Value = value
					});
				}
				threadPool.addTask(() => Invoke(new ThreadStart(() => dataTable.Rows.Add(row))), 0);
			}

			threadPool.addTask(() => Invoke(new ThreadStart(delegate {
				debugf.write(String.Format("Init {0} rows", lines.Length));
				disableLoading();
			})), 0);
			*/
		}

		private void processSave(object param) {
			if (dataDefinesFile == null) return;

//			mutex.WaitOne();

			Invoke(new ThreadStart(enableLoading));
			isSaved = true;

			if (!checkData()) {
				Invoke(new ThreadStart(delegate {
					debugf.write("Cannot save empty rows!");
					MessageBox.Show(this, "Cannot save empty rows!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
				isSaved = false;
//				mutex.ReleaseMutex();
				return;
			}

			string[] lines = collectData();

			string modFile = IOUtils.getTempFile();
			using (FileStream fs = File.Create(modFile)) {
				foreach (var line in lines) {
					var binare = Encoding.GetEncoding(encodingf.sOutputEncoding).GetBytes(line);
					if (encodingf.bReEncEnable)
						binare = Encoding.Convert(Encoding.GetEncoding(encodingf.sOutputEncoding), 
												  Encoding.GetEncoding(encodingf.sReEncEncoding), 
												  binare);
					
					fs.Write(binare, 0, binare.Length);
					fs.Flush();
				}
			}

			string asmFile = IOUtils.getTempFile();
			if (!crypt.asmFile(modFile, asmFile, dataDefinesFile, encodingf.bEncDecASCII)) {
				File.Delete(modFile);
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed asm file");
					MessageBox.Show(this, "Failed asm file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				isSaved = false;
				return;
			}


			string encFile = IOUtils.getTempFile();
			if(!crypt.encryptFile(asmFile, encFile, encdecVersion)) {
				File.Delete(modFile);
				File.Delete(asmFile);
				Invoke(new ThreadStart(delegate {
					debugf.write(crypt.getOut());
					debugf.write("Failed decode file");
					MessageBox.Show(this, "Failed encode file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					disableLoading();
				}));
//				mutex.ReleaseMutex();
				isSaved = false;
				return;
			}

			Invoke(new ThreadStart(() => debugf.write(crypt.getOut())));

			var saveTo = (string) param;
			if (File.Exists(saveTo)) {
				var backFile = String.Format("{0}.{1}", saveTo, ".backup");
				if(File.Exists(backFile))
					File.Delete(backFile);
				File.Copy(saveTo, backFile);
				File.Delete(saveTo);
			}
			
			File.Copy(encFile, saveTo);

			Invoke(new ThreadStart(disableLoading));
//			mutex.ReleaseMutex();
		}

		private string[] collectData() {
			string[] sRows = new string[dataTable.RowCount]; //first - colums
			for (int i = 0; i < dataTable.RowCount-1; i++) {
				string row = string.Empty;
				for (int j = 0; j < dataTable.Rows[i].Cells.Count; j++) {
					//var columnName = dataTable.Columns[j].Name;
					var cellValue = (string) dataTable.Rows[i].Cells[j].Value;

					//обработка массивов
					/*if (cellValue.Equals(string.Empty) && columnName.Contains("[") && columnName.Contains("]")) {
						int element = int.Parse(columnName[columnName.IndexOf('[') + 1].ToString()); //remove ']'
						int a;
						for (a = j; a >= 0; a--) {
							if (dataTable.Columns[a].Name.Contains("[") && dataTable.Columns[a].Name.Contains("]"))
								continue;
							break;
						}
						if (a < 0)
							return null;

						int max = int.Parse(dataTable.Rows[i].Cells[a].Value.ToString());
						if (element > max - 1)
							break;
					}*/
					row += String.Format("{0}\t", cellValue);
				}
				sRows[i + 1] = row.Substring(0, row.Length - 1) + "\n"; //remove last \t
			}

			sRows[0] = string.Empty;
			for (int i = 0; i < dataTable.ColumnCount; i++)
				sRows[0] += dataTable.Columns[i].Name + "\t";
			sRows[0] = sRows[0].Substring(0, sRows[0].Length - 1) + "\n";

			return sRows;
		}

		private bool checkData() {
			for (int i = 0; i < dataTable.RowCount - 1; i++) {
				bool empty = true;
				for (int j = 0; j < dataTable.Rows[i].Cells.Count; j++)
					if (dataTable.Rows[i].Cells[j].Value != null && !dataTable.Rows[i].Cells[j].Value.Equals(string.Empty)) {
						empty = false;
						break;
					}

				if (empty) {
					if (MessageBox.Show(this, String.Format("Detected empty rows {0}, delete?", i), "Empty rows", MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes) {
						int i1 = i;
						Invoke(new ThreadStart(() => dataTable.Rows.RemoveAt(i1)));
						continue;
					}
					return false;
				}
			}
			return true;
		}

		
	}
}
