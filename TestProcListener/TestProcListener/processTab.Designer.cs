namespace NoteKeeper
{
	partial class ProcessTab
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
			this.stopWatchingButton = new System.Windows.Forms.Button();
			this.closeWindowButton = new System.Windows.Forms.Button();
			this.renameButton = new System.Windows.Forms.Button();
			this.fontSettingsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// notesRichTextBox
			// 
			this.notesRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.notesRichTextBox.Location = new System.Drawing.Point(3, 35);
			this.notesRichTextBox.Name = "notesRichTextBox";
			this.notesRichTextBox.Size = new System.Drawing.Size(769, 499);
			this.notesRichTextBox.TabIndex = 0;
			this.notesRichTextBox.Text = "";
			// 
			// stopWatchingButton
			// 
			this.stopWatchingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.stopWatchingButton.Location = new System.Drawing.Point(601, 6);
			this.stopWatchingButton.Name = "stopWatchingButton";
			this.stopWatchingButton.Size = new System.Drawing.Size(91, 23);
			this.stopWatchingButton.TabIndex = 1;
			this.stopWatchingButton.Text = "Stop Watching";
			this.stopWatchingButton.UseVisualStyleBackColor = true;
			this.stopWatchingButton.Click += new System.EventHandler(this.stopWatchingButton_Click);
			// 
			// closeWindowButton
			// 
			this.closeWindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeWindowButton.Location = new System.Drawing.Point(698, 6);
			this.closeWindowButton.Name = "closeWindowButton";
			this.closeWindowButton.Size = new System.Drawing.Size(75, 23);
			this.closeWindowButton.TabIndex = 2;
			this.closeWindowButton.Text = "Close";
			this.closeWindowButton.UseVisualStyleBackColor = true;
			this.closeWindowButton.Click += new System.EventHandler(this.closeWindowButton_Click);
			// 
			// renameButton
			// 
			this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.renameButton.Location = new System.Drawing.Point(491, 6);
			this.renameButton.Name = "renameButton";
			this.renameButton.Size = new System.Drawing.Size(104, 23);
			this.renameButton.TabIndex = 3;
			this.renameButton.Text = "Rename Note Tab";
			this.renameButton.UseVisualStyleBackColor = true;
			this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
			// 
			// fontSettingsButton
			// 
			this.fontSettingsButton.Location = new System.Drawing.Point(3, 6);
			this.fontSettingsButton.Name = "fontSettingsButton";
			this.fontSettingsButton.Size = new System.Drawing.Size(87, 23);
			this.fontSettingsButton.TabIndex = 4;
			this.fontSettingsButton.Text = "Font Settings";
			this.fontSettingsButton.UseVisualStyleBackColor = true;
			this.fontSettingsButton.Click += new System.EventHandler(this.fontSettingsButton_Click);
			// 
			// ProcessTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.fontSettingsButton);
			this.Controls.Add(this.renameButton);
			this.Controls.Add(this.closeWindowButton);
			this.Controls.Add(this.stopWatchingButton);
			this.Controls.Add(this.notesRichTextBox);
			this.Name = "ProcessTab";
			this.Size = new System.Drawing.Size(776, 535);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox notesRichTextBox;
		private System.Windows.Forms.Button stopWatchingButton;
		private System.Windows.Forms.Button closeWindowButton;
		private System.Windows.Forms.Button renameButton;
		private System.Windows.Forms.Button fontSettingsButton;
	}
}
