namespace L2REditorIni {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.openButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.closeButton = new System.Windows.Forms.ToolStripMenuItem();
			this.makeBackupButton = new System.Windows.Forms.ToolStripMenuItem();
			this.presetsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.l2iniButton = new System.Windows.Forms.ToolStripMenuItem();
			this.chaneIpButton = new System.Windows.Forms.ToolStripMenuItem();
			this.devModeButton = new System.Windows.Forms.ToolStripMenuItem();
			this.changeLangButton = new System.Windows.Forms.ToolStripMenuItem();
			this.changeWindowButton = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.findBox = new System.Windows.Forms.ToolStripTextBox();
			this.sectionsTree = new System.Windows.Forms.TreeView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.loadingCircle = new L2REditor.Engine.GUI.LoadingCircle();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.presetsMenu,
            this.viewMenu,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.findBox});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(699, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// fileMenu
			// 
			this.fileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.saveAsButton,
            this.closeButton,
            this.makeBackupButton});
			this.fileMenu.Image = ((System.Drawing.Image)(resources.GetObject("fileMenu.Image")));
			this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(38, 22);
			this.fileMenu.Text = "File";
			// 
			// openButton
			// 
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(145, 22);
			this.openButton.Text = "Open";
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(145, 22);
			this.saveButton.Text = "Save";
			this.saveButton.Click += new System.EventHandler(this.saveMenu_Click);
			// 
			// saveAsButton
			// 
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new System.Drawing.Size(145, 22);
			this.saveAsButton.Text = "Save as...";
			this.saveAsButton.Click += new System.EventHandler(this.saveAsMenu_Click);
			// 
			// closeButton
			// 
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(145, 22);
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeMenu_Click);
			// 
			// makeBackupButton
			// 
			this.makeBackupButton.Checked = true;
			this.makeBackupButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.makeBackupButton.Name = "makeBackupButton";
			this.makeBackupButton.Size = new System.Drawing.Size(145, 22);
			this.makeBackupButton.Text = "Make backup";
			this.makeBackupButton.Click += new System.EventHandler(this.makeBackupButton_Click);
			// 
			// presetsMenu
			// 
			this.presetsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.presetsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l2iniButton});
			this.presetsMenu.Image = ((System.Drawing.Image)(resources.GetObject("presetsMenu.Image")));
			this.presetsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.presetsMenu.Name = "presetsMenu";
			this.presetsMenu.Size = new System.Drawing.Size(57, 22);
			this.presetsMenu.Text = "Presets";
			// 
			// l2iniButton
			// 
			this.l2iniButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chaneIpButton,
            this.devModeButton,
            this.changeLangButton,
            this.changeWindowButton});
			this.l2iniButton.Name = "l2iniButton";
			this.l2iniButton.Size = new System.Drawing.Size(102, 22);
			this.l2iniButton.Text = "L2.ini";
			// 
			// chaneIpButton
			// 
			this.chaneIpButton.Name = "chaneIpButton";
			this.chaneIpButton.Size = new System.Drawing.Size(161, 22);
			this.chaneIpButton.Text = "Change IP";
			this.chaneIpButton.Click += new System.EventHandler(this.chaneIpButton_Click);
			// 
			// devModeButton
			// 
			this.devModeButton.Name = "devModeButton";
			this.devModeButton.Size = new System.Drawing.Size(161, 22);
			this.devModeButton.Text = "Developer mode";
			this.devModeButton.Click += new System.EventHandler(this.devModeButton_Click);
			// 
			// changeLangButton
			// 
			this.changeLangButton.Name = "changeLangButton";
			this.changeLangButton.Size = new System.Drawing.Size(161, 22);
			this.changeLangButton.Text = "Change lang";
			this.changeLangButton.Click += new System.EventHandler(this.changeLangButton_Click);
			// 
			// changeWindowButton
			// 
			this.changeWindowButton.Name = "changeWindowButton";
			this.changeWindowButton.Size = new System.Drawing.Size(161, 22);
			this.changeWindowButton.Text = "Change window";
			this.changeWindowButton.Click += new System.EventHandler(this.changeWindowButton_Click);
			// 
			// viewMenu
			// 
			this.viewMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputToolStripMenuItem});
			this.viewMenu.Image = ((System.Drawing.Image)(resources.GetObject("viewMenu.Image")));
			this.viewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(45, 22);
			this.viewMenu.Text = "View";
			// 
			// outputToolStripMenuItem
			// 
			this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
			this.outputToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.outputToolStripMenuItem.Text = "Output";
			this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputMenu_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(30, 22);
			this.toolStripLabel1.Text = "Find";
			// 
			// findBox
			// 
			this.findBox.Name = "findBox";
			this.findBox.Size = new System.Drawing.Size(100, 25);
			// 
			// sectionsTree
			// 
			this.sectionsTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sectionsTree.Location = new System.Drawing.Point(12, 28);
			this.sectionsTree.Name = "sectionsTree";
			this.sectionsTree.Size = new System.Drawing.Size(675, 444);
			this.sectionsTree.TabIndex = 1;
			this.sectionsTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.sectionsTree_NodeMouseClick);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(12, 478);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(675, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
			// saveFileDialog1
			// 
			this.saveFileDialog1.RestoreDirectory = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "INI Files|*.ini|INT Files|*.int";
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 510);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.sectionsTree);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "L2REditorIni";
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton fileMenu;
		private System.Windows.Forms.ToolStripMenuItem openButton;
		private System.Windows.Forms.ToolStripMenuItem saveButton;
		private System.Windows.Forms.ToolStripMenuItem saveAsButton;
		private System.Windows.Forms.ToolStripMenuItem closeButton;
		private System.Windows.Forms.ToolStripDropDownButton viewMenu;
		private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
		private System.Windows.Forms.TreeView sectionsTree;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripMenuItem makeBackupButton;
		private System.Windows.Forms.ToolStripDropDownButton presetsMenu;
		private System.Windows.Forms.ToolStripMenuItem l2iniButton;
		private System.Windows.Forms.ToolStripMenuItem chaneIpButton;
		private System.Windows.Forms.ToolStripMenuItem devModeButton;
		private System.Windows.Forms.ToolStripMenuItem changeLangButton;
		private System.Windows.Forms.ToolStripMenuItem changeWindowButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox findBox;
		private L2REditor.Engine.GUI.LoadingCircle loadingCircle;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

