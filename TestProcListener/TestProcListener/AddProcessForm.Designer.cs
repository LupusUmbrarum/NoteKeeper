namespace TestProcListener
{
	partial class AddProcessForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.procNameLabel = new System.Windows.Forms.Label();
			this.mainWindowTitleLabel = new System.Windows.Forms.Label();
			this.prefProcNameTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Process Name (In System):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Process\' Main Window Title:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Preferred Process Name:";
			this.label3.UseCompatibleTextRendering = true;
			// 
			// procNameLabel
			// 
			this.procNameLabel.AutoSize = true;
			this.procNameLabel.Location = new System.Drawing.Point(159, 9);
			this.procNameLabel.Name = "procNameLabel";
			this.procNameLabel.Size = new System.Drawing.Size(78, 13);
			this.procNameLabel.TabIndex = 3;
			this.procNameLabel.Text = "__procname__";
			// 
			// mainWindowTitleLabel
			// 
			this.mainWindowTitleLabel.AutoSize = true;
			this.mainWindowTitleLabel.Location = new System.Drawing.Point(159, 37);
			this.mainWindowTitleLabel.Name = "mainWindowTitleLabel";
			this.mainWindowTitleLabel.Size = new System.Drawing.Size(105, 13);
			this.mainWindowTitleLabel.TabIndex = 4;
			this.mainWindowTitleLabel.Text = "__mainwindowtitle__";
			// 
			// prefProcNameTextBox
			// 
			this.prefProcNameTextBox.Location = new System.Drawing.Point(143, 63);
			this.prefProcNameTextBox.Name = "prefProcNameTextBox";
			this.prefProcNameTextBox.Size = new System.Drawing.Size(174, 20);
			this.prefProcNameTextBox.TabIndex = 0;
			this.prefProcNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.prefProcNameTextBox_KeyUp);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(81, 89);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(162, 89);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// AddProcessForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 119);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.prefProcNameTextBox);
			this.Controls.Add(this.mainWindowTitleLabel);
			this.Controls.Add(this.procNameLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddProcessForm";
			this.Text = "AddProcessForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label procNameLabel;
		private System.Windows.Forms.Label mainWindowTitleLabel;
		private System.Windows.Forms.TextBox prefProcNameTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}