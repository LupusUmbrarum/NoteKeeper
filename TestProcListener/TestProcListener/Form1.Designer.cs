namespace TestProcListener
{
	partial class MainWindow
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.mainTabPage = new System.Windows.Forms.TabPage();
			this.procListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.refreshButton = new System.Windows.Forms.Button();
			this.addProcsButton = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.mainTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.mainTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 561);
			this.tabControl1.TabIndex = 0;
			// 
			// mainTabPage
			// 
			this.mainTabPage.Controls.Add(this.addProcsButton);
			this.mainTabPage.Controls.Add(this.procListView);
			this.mainTabPage.Controls.Add(this.refreshButton);
			this.mainTabPage.Location = new System.Drawing.Point(4, 22);
			this.mainTabPage.Name = "mainTabPage";
			this.mainTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.mainTabPage.Size = new System.Drawing.Size(776, 535);
			this.mainTabPage.TabIndex = 0;
			this.mainTabPage.Text = "Main Menu";
			this.mainTabPage.UseVisualStyleBackColor = true;
			// 
			// procListView
			// 
			this.procListView.AllowColumnReorder = true;
			this.procListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.procListView.Dock = System.Windows.Forms.DockStyle.Top;
			this.procListView.FullRowSelect = true;
			this.procListView.HideSelection = false;
			this.procListView.Location = new System.Drawing.Point(3, 3);
			this.procListView.Name = "procListView";
			this.procListView.Size = new System.Drawing.Size(770, 497);
			this.procListView.TabIndex = 4;
			this.procListView.UseCompatibleStateImageBehavior = false;
			this.procListView.View = System.Windows.Forms.View.Details;
			this.procListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.procListView_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "PID";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 268;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Main Window Title";
			this.columnHeader3.Width = 448;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(695, 506);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(75, 23);
			this.refreshButton.TabIndex = 3;
			this.refreshButton.Text = "Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// addProcsButton
			// 
			this.addProcsButton.Location = new System.Drawing.Point(569, 506);
			this.addProcsButton.Name = "addProcsButton";
			this.addProcsButton.Size = new System.Drawing.Size(120, 23);
			this.addProcsButton.TabIndex = 5;
			this.addProcsButton.Text = "Add Selected Process";
			this.addProcsButton.UseVisualStyleBackColor = true;
			this.addProcsButton.Click += new System.EventHandler(this.addProcsButton_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainWindow";
			this.Text = "Process Listener";
			this.tabControl1.ResumeLayout(false);
			this.mainTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage mainTabPage;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.ListView procListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button addProcsButton;
	}
}

