using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProcListener
{
	public partial class AddProcessForm : Form
	{
		public AddProcessForm(string procName, string mainWindowTitle)
		{
			InitializeComponent();

			procNameLabel.Text = procName;
			mainWindowTitleLabel.Text = mainWindowTitle;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			addProcessToWatcher(procNameLabel.Text, prefProcNameTextBox.Text);
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void prefProcNameTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				addProcessToWatcher(procNameLabel.Text, prefProcNameTextBox.Text);
				this.Close();
			}
		}

		private void addProcessToWatcher(string procName, string userProcName)
		{
			if(ProcessWatcher.getInstance().addToWatchedProcesses(procName, userProcName))
			{
				if(MessageBox.Show("You have begun watching the process " + procName + ".\nWould you like to open the notes for it?", 
					"Process Added", 
					MessageBoxButtons.YesNo, 
					MessageBoxIcon.Question) == DialogResult.Yes)
				{

				}
			}
		}
	}
}
