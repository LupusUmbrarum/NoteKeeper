namespace NoteKeeper
{
	partial class ChangeUserProcNameDialog
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
			this.oldNameLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.newNameTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Name:";
			// 
			// oldNameLabel
			// 
			this.oldNameLabel.AutoSize = true;
			this.oldNameLabel.Location = new System.Drawing.Point(94, 53);
			this.oldNameLabel.Name = "oldNameLabel";
			this.oldNameLabel.Size = new System.Drawing.Size(153, 13);
			this.oldNameLabel.TabIndex = 1;
			this.oldNameLabel.Text = "__original proc name________";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "New Name:";
			// 
			// newNameTextBox
			// 
			this.newNameTextBox.Location = new System.Drawing.Point(94, 79);
			this.newNameTextBox.Name = "newNameTextBox";
			this.newNameTextBox.Size = new System.Drawing.Size(153, 20);
			this.newNameTextBox.TabIndex = 3;
			this.newNameTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.newNameTextBox_PreviewKeyDown);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(61, 111);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(142, 111);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(248, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Enter the new name for the process\'s tab. The new";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "name cannot be blank.";
			// 
			// ChangeUserProcNameDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 147);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.newNameTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.oldNameLabel);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ChangeUserProcNameDialog";
			this.Text = "Change Process Name";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label oldNameLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox newNameTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}