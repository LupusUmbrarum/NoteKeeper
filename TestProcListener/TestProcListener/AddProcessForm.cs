using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteKeeper
{
	public partial class AddProcessForm : Form
	{
		private MainWindow parentMW;

		private bool enterBeenPressed = false;

		public AddProcessForm(string procName, string mainWindowTitle, MainWindow parentMW)
		{
			InitializeComponent();

			procNameLabel.Text = procName;
			mainWindowTitleLabel.Text = mainWindowTitle;
			this.parentMW = parentMW;

			StartPosition = FormStartPosition.CenterParent;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if(prefProcNameTextBox.Text == "")
			{
				addProcessToWatcher(procNameLabel.Text, procNameLabel.Text);
			}
			else
			{
				addProcessToWatcher(procNameLabel.Text, prefProcNameTextBox.Text);
			}
			
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void prefProcNameTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			
		}

		private void addProcessToWatcher(string procName, string userProcName)
		{
			ProcessWatcher.getInstance().addToWatchedProcesses(procName, userProcName);

			if(procName == "")
			{
				if (MessageBox.Show("You are watching the process \"" + userProcName + "\".\nWould you like to go to the notes for it?",
					"Process Added",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					parentMW.addProcessTab(procName, userProcName, true);
				}
				else
				{
					parentMW.addProcessTab(procName, userProcName, false);
				}
			}
			else
			{
				if (MessageBox.Show("You are watching the process \"" + procName + "\".\nWould you like to go to the notes for it?",
					"Process Added",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					parentMW.addProcessTab(procName, userProcName, true);
				}
				else
				{
					parentMW.addProcessTab(procName, userProcName, false);
				}
			}
		}

		private void prefProcNameTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (enterBeenPressed)
				{
					return;
				}

				enterBeenPressed = true;

				if (prefProcNameTextBox.Text == "")
				{
					addProcessToWatcher(procNameLabel.Text, procNameLabel.Text);
				}
				else
				{
					addProcessToWatcher(procNameLabel.Text, prefProcNameTextBox.Text);
				}

				Close();
			}
		}
	}
}