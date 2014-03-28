namespace L2REditor {
	partial class EncodingForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.enableReEncode = new System.Windows.Forms.CheckBox();
			this.inputEncoding = new System.Windows.Forms.ComboBox();
			this.encDecEncoding = new System.Windows.Forms.ComboBox();
			this.outputEncoding = new System.Windows.Forms.ComboBox();
			this.reEncode = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(139, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "EncDec encoding";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(139, 35);
			this.label2.Margin = new System.Windows.Forms.Padding(3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Input encode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(139, 62);
			this.label3.Margin = new System.Windows.Forms.Padding(3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Output encode";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(285, 35);
			this.label4.Margin = new System.Windows.Forms.Padding(3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Re-encode to";
			// 
			// enableReEncode
			// 
			this.enableReEncode.AutoSize = true;
			this.enableReEncode.Location = new System.Drawing.Point(374, 9);
			this.enableReEncode.Name = "enableReEncode";
			this.enableReEncode.Size = new System.Drawing.Size(110, 17);
			this.enableReEncode.TabIndex = 1;
			this.enableReEncode.Text = "Enable re-encode";
			this.enableReEncode.UseVisualStyleBackColor = true;
			this.enableReEncode.CheckedChanged += new System.EventHandler(this.enableReEncode_CheckedChanged);
			// 
			// inputEncoding
			// 
			this.inputEncoding.FormattingEnabled = true;
			this.inputEncoding.Items.AddRange(new object[] {
            "Windows-1251",
            "ASCII",
            "UTF-7",
            "UTF-8",
            "UTF-32",
            "Unicode"});
			this.inputEncoding.Location = new System.Drawing.Point(12, 32);
			this.inputEncoding.Name = "inputEncoding";
			this.inputEncoding.Size = new System.Drawing.Size(121, 21);
			this.inputEncoding.TabIndex = 2;
			this.inputEncoding.Text = "Windows-1251";
			this.inputEncoding.TextChanged += new System.EventHandler(this.encoding_TextChanged);
			// 
			// encDecEncoding
			// 
			this.encDecEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.encDecEncoding.FormattingEnabled = true;
			this.encDecEncoding.Items.AddRange(new object[] {
            "ASCII",
            "UTF-8"});
			this.encDecEncoding.Location = new System.Drawing.Point(12, 5);
			this.encDecEncoding.Name = "encDecEncoding";
			this.encDecEncoding.Size = new System.Drawing.Size(121, 21);
			this.encDecEncoding.TabIndex = 2;
			this.encDecEncoding.SelectedIndexChanged += new System.EventHandler(this.encDecEncoding_SelectedIndexChanged);
			// 
			// outputEncoding
			// 
			this.outputEncoding.FormattingEnabled = true;
			this.outputEncoding.Items.AddRange(new object[] {
            "Windows-1251",
            "ASCII",
            "UTF-7",
            "UTF-8",
            "UTF-32",
            "Unicode"});
			this.outputEncoding.Location = new System.Drawing.Point(12, 59);
			this.outputEncoding.Name = "outputEncoding";
			this.outputEncoding.Size = new System.Drawing.Size(121, 21);
			this.outputEncoding.TabIndex = 2;
			this.outputEncoding.Text = "Windows-1251";
			this.outputEncoding.TextChanged += new System.EventHandler(this.encoding_TextChanged);
			// 
			// reEncode
			// 
			this.reEncode.Enabled = false;
			this.reEncode.FormattingEnabled = true;
			this.reEncode.Items.AddRange(new object[] {
            "Windows-1251",
            "ASCII",
            "UTF-7",
            "UTF-8",
            "UTF-32",
            "Unicode"});
			this.reEncode.Location = new System.Drawing.Point(363, 32);
			this.reEncode.Name = "reEncode";
			this.reEncode.Size = new System.Drawing.Size(121, 21);
			this.reEncode.TabIndex = 2;
			this.reEncode.TextChanged += new System.EventHandler(this.encoding_TextChanged);
			// 
			// EncodingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 92);
			this.Controls.Add(this.encDecEncoding);
			this.Controls.Add(this.reEncode);
			this.Controls.Add(this.outputEncoding);
			this.Controls.Add(this.inputEncoding);
			this.Controls.Add(this.enableReEncode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EncodingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "L2REditor Encoding";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EncodingForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox enableReEncode;
		private System.Windows.Forms.ComboBox inputEncoding;
		private System.Windows.Forms.ComboBox encDecEncoding;
		private System.Windows.Forms.ComboBox outputEncoding;
		private System.Windows.Forms.ComboBox reEncode;
	}
}