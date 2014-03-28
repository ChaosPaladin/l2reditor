using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace L2REditor {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dataTable = new System.Windows.Forms.DataGridView();
			this.columnMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.addBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preEditor = new System.Windows.Forms.TextBox();
			this.openEditorButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.statusStrip1 = new System.Windows.Forms.ToolStrip();
			this.fileButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.asmVersionButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.c3Button = new System.Windows.Forms.ToolStripMenuItem();
			this.c4Button = new System.Windows.Forms.ToolStripMenuItem();
			this.c5Button = new System.Windows.Forms.ToolStripMenuItem();
			this.c6Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct10Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct15Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct21Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct22Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct22ruButton = new System.Windows.Forms.ToolStripMenuItem();
			this.ct23Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct23krButton = new System.Windows.Forms.ToolStripMenuItem();
			this.ct23ruButton = new System.Windows.Forms.ToolStripMenuItem();
			this.ct24Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct24ruButton = new System.Windows.Forms.ToolStripMenuItem();
			this.ct25Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct26Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct31Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct32Button = new System.Windows.Forms.ToolStripMenuItem();
			this.ct33Button = new System.Windows.Forms.ToolStripMenuItem();
			this.utilButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.encodingButton = new System.Windows.Forms.ToolStripMenuItem();
			this.debugButton = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.jumpToColumn = new System.Windows.Forms.ToolStripTextBox();
			this.findType = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.rowSelectId = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.columnSelectId = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.loadingCircle = new L2REditor.Engine.GUI.LoadingCircle();
			this.labelDrag = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
			this.columnMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataTable
			// 
			this.dataTable.AllowUserToOrderColumns = true;
			this.dataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataTable.Location = new System.Drawing.Point(12, 25);
			this.dataTable.Name = "dataTable";
			this.dataTable.Size = new System.Drawing.Size(799, 466);
			this.dataTable.TabIndex = 1;
			this.dataTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellSelect);
			this.dataTable.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_rowMouseClick);
			this.dataTable.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.table_sortCompare);
			this.dataTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataTable_KeyDown);
			// 
			// columnMenu
			// 
			this.columnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.addBeforeToolStripMenuItem,
            this.addAfterToolStripMenuItem,
            this.clearToolStripMenuItem});
			this.columnMenu.Name = "columnMenu";
			this.columnMenu.Size = new System.Drawing.Size(134, 92);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(133, 22);
			this.toolStripMenuItem4.Text = "Delete";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.table_deleteButton_Click);
			// 
			// addBeforeToolStripMenuItem
			// 
			this.addBeforeToolStripMenuItem.Name = "addBeforeToolStripMenuItem";
			this.addBeforeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.addBeforeToolStripMenuItem.Text = "Add before";
			this.addBeforeToolStripMenuItem.Click += new System.EventHandler(this.table_addBeforeButton_Click);
			// 
			// addAfterToolStripMenuItem
			// 
			this.addAfterToolStripMenuItem.Name = "addAfterToolStripMenuItem";
			this.addAfterToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.addAfterToolStripMenuItem.Text = "Add after";
			this.addAfterToolStripMenuItem.Click += new System.EventHandler(this.table_addAfterButton_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.table_clearButton_Click);
			// 
			// preEditor
			// 
			this.preEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.preEditor.Location = new System.Drawing.Point(12, 499);
			this.preEditor.Name = "preEditor";
			this.preEditor.Size = new System.Drawing.Size(768, 20);
			this.preEditor.TabIndex = 2;
			this.preEditor.TextChanged += new System.EventHandler(this.preEditor_TextChanged);
			// 
			// openEditorButton
			// 
			this.openEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.openEditorButton.Enabled = false;
			this.openEditorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.openEditorButton.Location = new System.Drawing.Point(786, 497);
			this.openEditorButton.Name = "openEditorButton";
			this.openEditorButton.Size = new System.Drawing.Size(25, 23);
			this.openEditorButton.TabIndex = 3;
			this.openEditorButton.Text = "...";
			this.openEditorButton.UseVisualStyleBackColor = true;
			this.openEditorButton.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "DAT|*.dat";
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.asmVersionButton,
            this.utilButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.jumpToColumn,
            this.findType,
            this.toolStripSeparator2,
            this.toolStripStatusLabel1,
            this.rowSelectId,
            this.toolStripStatusLabel2,
            this.columnSelectId});
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(823, 25);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// fileButton
			// 
			this.fileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem3});
			this.fileButton.Image = ((System.Drawing.Image)(resources.GetObject("fileButton.Image")));
			this.fileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(38, 22);
			this.fileButton.Text = "File";
			this.fileButton.MouseHover += new System.EventHandler(this.menuButtons_MouseHover);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
			this.toolStripMenuItem1.Text = "Open";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.openFile_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
			this.toolStripMenuItem2.Text = "Save";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsButton_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(121, 22);
			this.toolStripMenuItem3.Text = "Close";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// asmVersionButton
			// 
			this.asmVersionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.asmVersionButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c3Button,
            this.c4Button,
            this.c5Button,
            this.c6Button,
            this.ct10Button,
            this.ct15Button,
            this.ct21Button,
            this.ct22Button,
            this.ct22ruButton,
            this.ct23Button,
            this.ct23krButton,
            this.ct23ruButton,
            this.ct24Button,
            this.ct24ruButton,
            this.ct25Button,
            this.ct26Button,
            this.ct31Button,
            this.ct32Button,
            this.ct33Button});
			this.asmVersionButton.Image = ((System.Drawing.Image)(resources.GetObject("asmVersionButton.Image")));
			this.asmVersionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.asmVersionButton.Name = "asmVersionButton";
			this.asmVersionButton.Size = new System.Drawing.Size(87, 22);
			this.asmVersionButton.Text = "ASM Version";
			this.asmVersionButton.MouseHover += new System.EventHandler(this.menuButtons_MouseHover);
			// 
			// c3Button
			// 
			this.c3Button.CheckOnClick = true;
			this.c3Button.Name = "c3Button";
			this.c3Button.Size = new System.Drawing.Size(125, 22);
			this.c3Button.Text = "C3";
			this.c3Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// c4Button
			// 
			this.c4Button.CheckOnClick = true;
			this.c4Button.Name = "c4Button";
			this.c4Button.Size = new System.Drawing.Size(125, 22);
			this.c4Button.Text = "C4";
			this.c4Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// c5Button
			// 
			this.c5Button.CheckOnClick = true;
			this.c5Button.Name = "c5Button";
			this.c5Button.Size = new System.Drawing.Size(125, 22);
			this.c5Button.Text = "C5";
			this.c5Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// c6Button
			// 
			this.c6Button.CheckOnClick = true;
			this.c6Button.Name = "c6Button";
			this.c6Button.Size = new System.Drawing.Size(125, 22);
			this.c6Button.Text = "Interlude";
			this.c6Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct10Button
			// 
			this.ct10Button.CheckOnClick = true;
			this.ct10Button.Name = "ct10Button";
			this.ct10Button.Size = new System.Drawing.Size(125, 22);
			this.ct10Button.Text = "CT 1.0";
			this.ct10Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct15Button
			// 
			this.ct15Button.CheckOnClick = true;
			this.ct15Button.Name = "ct15Button";
			this.ct15Button.Size = new System.Drawing.Size(125, 22);
			this.ct15Button.Text = "CT 1.5";
			this.ct15Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct21Button
			// 
			this.ct21Button.CheckOnClick = true;
			this.ct21Button.Name = "ct21Button";
			this.ct21Button.Size = new System.Drawing.Size(125, 22);
			this.ct21Button.Text = "CT 2.1";
			this.ct21Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct22Button
			// 
			this.ct22Button.CheckOnClick = true;
			this.ct22Button.Name = "ct22Button";
			this.ct22Button.Size = new System.Drawing.Size(125, 22);
			this.ct22Button.Text = "CT 2.2";
			this.ct22Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct22ruButton
			// 
			this.ct22ruButton.CheckOnClick = true;
			this.ct22ruButton.Name = "ct22ruButton";
			this.ct22ruButton.Size = new System.Drawing.Size(125, 22);
			this.ct22ruButton.Text = "CT 2.2 RU";
			this.ct22ruButton.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct23Button
			// 
			this.ct23Button.CheckOnClick = true;
			this.ct23Button.Name = "ct23Button";
			this.ct23Button.Size = new System.Drawing.Size(125, 22);
			this.ct23Button.Text = "CT 2.3 EN";
			this.ct23Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct23krButton
			// 
			this.ct23krButton.CheckOnClick = true;
			this.ct23krButton.Name = "ct23krButton";
			this.ct23krButton.Size = new System.Drawing.Size(125, 22);
			this.ct23krButton.Text = "CT 2.3 KR";
			this.ct23krButton.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct23ruButton
			// 
			this.ct23ruButton.CheckOnClick = true;
			this.ct23ruButton.Name = "ct23ruButton";
			this.ct23ruButton.Size = new System.Drawing.Size(125, 22);
			this.ct23ruButton.Text = "CT 2.3 RU";
			this.ct23ruButton.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct24Button
			// 
			this.ct24Button.CheckOnClick = true;
			this.ct24Button.Name = "ct24Button";
			this.ct24Button.Size = new System.Drawing.Size(125, 22);
			this.ct24Button.Text = "CT 2.4 EN";
			this.ct24Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct24ruButton
			// 
			this.ct24ruButton.CheckOnClick = true;
			this.ct24ruButton.Name = "ct24ruButton";
			this.ct24ruButton.Size = new System.Drawing.Size(125, 22);
			this.ct24ruButton.Text = "CT 2.4 RU";
			this.ct24ruButton.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct25Button
			// 
			this.ct25Button.CheckOnClick = true;
			this.ct25Button.Name = "ct25Button";
			this.ct25Button.Size = new System.Drawing.Size(125, 22);
			this.ct25Button.Text = "CT 2.5 EN";
			this.ct25Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct26Button
			// 
			this.ct26Button.CheckOnClick = true;
			this.ct26Button.Name = "ct26Button";
			this.ct26Button.Size = new System.Drawing.Size(125, 22);
			this.ct26Button.Text = "CT 2.6 EN";
			this.ct26Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct31Button
			// 
			this.ct31Button.CheckOnClick = true;
			this.ct31Button.Name = "ct31Button";
			this.ct31Button.Size = new System.Drawing.Size(125, 22);
			this.ct31Button.Text = "CT 3.1 EN";
			this.ct31Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct32Button
			// 
			this.ct32Button.CheckOnClick = true;
			this.ct32Button.Name = "ct32Button";
			this.ct32Button.Size = new System.Drawing.Size(125, 22);
			this.ct32Button.Text = "CT 3.2 EN";
			this.ct32Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// ct33Button
			// 
			this.ct33Button.CheckOnClick = true;
			this.ct33Button.Name = "ct33Button";
			this.ct33Button.Size = new System.Drawing.Size(125, 22);
			this.ct33Button.Text = "CT 3.3 EN";
			this.ct33Button.Click += new System.EventHandler(this.versionSelect_Click);
			// 
			// utilButton
			// 
			this.utilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.utilButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingButton,
            this.debugButton});
			this.utilButton.Image = ((System.Drawing.Image)(resources.GetObject("utilButton.Image")));
			this.utilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.utilButton.Name = "utilButton";
			this.utilButton.Size = new System.Drawing.Size(45, 22);
			this.utilButton.Text = "View";
			this.utilButton.MouseHover += new System.EventHandler(this.menuButtons_MouseHover);
			// 
			// encodingButton
			// 
			this.encodingButton.Name = "encodingButton";
			this.encodingButton.Size = new System.Drawing.Size(157, 22);
			this.encodingButton.Text = "Encoding";
			this.encodingButton.Click += new System.EventHandler(this.encodingButton_Click);
			// 
			// debugButton
			// 
			this.debugButton.Name = "debugButton";
			this.debugButton.Size = new System.Drawing.Size(157, 22);
			this.debugButton.Text = "Output window";
			this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
			this.toolStripLabel1.Text = "Jump";
			// 
			// jumpToColumn
			// 
			this.jumpToColumn.Name = "jumpToColumn";
			this.jumpToColumn.Size = new System.Drawing.Size(100, 25);
			this.jumpToColumn.TextChanged += new System.EventHandler(this.jumpToColumn_TextChanged);
			// 
			// findType
			// 
			this.findType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.findType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.findType.Name = "findType";
			this.findType.Size = new System.Drawing.Size(121, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 20);
			this.toolStripStatusLabel1.Text = "Row:";
			// 
			// rowSelectId
			// 
			this.rowSelectId.Name = "rowSelectId";
			this.rowSelectId.Size = new System.Drawing.Size(13, 20);
			this.rowSelectId.Text = "0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(53, 20);
			this.toolStripStatusLabel2.Text = "Column:";
			// 
			// columnSelectId
			// 
			this.columnSelectId.Name = "columnSelectId";
			this.columnSelectId.Size = new System.Drawing.Size(13, 20);
			this.columnSelectId.Text = "0";
			// 
			// loadingCircle
			// 
			this.loadingCircle.Active = false;
			this.loadingCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
			this.loadingCircle.Color = System.Drawing.Color.DarkGray;
			this.loadingCircle.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.loadingCircle.InnerCircleRadius = 5;
			this.loadingCircle.Location = new System.Drawing.Point(0, 0);
			this.loadingCircle.Name = "loadingCircle";
			this.loadingCircle.NumberSpoke = 12;
			this.loadingCircle.OuterCircleRadius = 11;
			this.loadingCircle.RotationSpeed = 100;
			this.loadingCircle.Size = new System.Drawing.Size(0, 0);
			this.loadingCircle.SpokeThickness = 2;
			this.loadingCircle.StylePreset = L2REditor.Engine.GUI.LoadingCircle.StylePresets.MacOSX;
			this.loadingCircle.TabIndex = 5;
			this.loadingCircle.Text = "loadingCircle";
			this.loadingCircle.Visible = false;
			// 
			// labelDrag
			// 
			this.labelDrag.BackColor = System.Drawing.Color.LightGray;
			this.labelDrag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDrag.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.labelDrag.Image = global::L2REditor.Properties.Resources._6;
			this.labelDrag.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.labelDrag.Location = new System.Drawing.Point(0, 25);
			this.labelDrag.Name = "labelDrag";
			this.labelDrag.Size = new System.Drawing.Size(823, 506);
			this.labelDrag.TabIndex = 6;
			this.labelDrag.Text = "Drag-and-Drop";
			this.labelDrag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.labelDrag.Visible = false;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(823, 531);
			this.Controls.Add(this.labelDrag);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.openEditorButton);
			this.Controls.Add(this.preEditor);
			this.Controls.Add(this.dataTable);
			this.Controls.Add(this.loadingCircle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "L2REditor Dat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnter);
			this.DragLeave += new System.EventHandler(this.dragLeave);
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
			this.columnMenu.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataTable;
		private System.Windows.Forms.TextBox preEditor;
		private System.Windows.Forms.Button openEditorButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStrip statusStrip1;
		private System.Windows.Forms.ToolStripDropDownButton fileButton;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripDropDownButton asmVersionButton;
		private System.Windows.Forms.ToolStripMenuItem c5Button;
		private System.Windows.Forms.ToolStripMenuItem c6Button;
		private System.Windows.Forms.ToolStripMenuItem ct10Button;
		private System.Windows.Forms.ToolStripMenuItem ct15Button;
		private System.Windows.Forms.ToolStripMenuItem ct21Button;
		private System.Windows.Forms.ToolStripMenuItem ct22Button;
		private System.Windows.Forms.ToolStripMenuItem ct22ruButton;
		private System.Windows.Forms.ToolStripMenuItem ct23Button;
		private System.Windows.Forms.ToolStripMenuItem ct23krButton;
		private System.Windows.Forms.ToolStripMenuItem ct23ruButton;
		private System.Windows.Forms.ToolStripMenuItem ct24Button;
		private System.Windows.Forms.ToolStripMenuItem ct24ruButton;
		private System.Windows.Forms.ToolStripMenuItem ct25Button;
		private ToolStripMenuItem ct26Button;
		private ToolStripMenuItem ct31Button;
		private ToolStripMenuItem ct32Button;
		private ToolStripMenuItem ct33Button;
		private ToolStripDropDownButton utilButton;
		private ToolStripMenuItem debugButton;
		private ToolStripMenuItem c3Button;
		private System.Windows.Forms.ToolStripMenuItem c4Button;
		private L2REditor.Engine.GUI.LoadingCircle loadingCircle;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ToolStripStatusLabel rowSelectId;
		private ContextMenuStrip columnMenu;
		private ToolStripMenuItem toolStripMenuItem4;
		private ToolStripMenuItem addBeforeToolStripMenuItem;
		private ToolStripMenuItem addAfterToolStripMenuItem;
		private ToolStripMenuItem saveAsToolStripMenuItem;
		private ToolStripStatusLabel toolStripStatusLabel2;
		private ToolStripStatusLabel columnSelectId;
		private SaveFileDialog saveFileDialog1;
		private ToolStripMenuItem clearToolStripMenuItem;
		private ToolStripLabel toolStripLabel1;
		private ToolStripTextBox jumpToColumn;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripComboBox findType;
		private Label labelDrag;
		private ToolStripMenuItem encodingButton;
	}
}

