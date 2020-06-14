using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteKeeper
{
	public partial class ProcessTab : UserControl
	{
		private MainWindow parentMW;
		public string procName = "", userProcName = "";
		private FontDialog fd;

		public ProcessTab(string procName, string userProcName, MainWindow parentMW)
		{
			InitializeComponent();

			this.procName = procName;
			this.userProcName = userProcName;
			this.parentMW = parentMW;

			notesRichTextBox.Text = ProcessWatcher.getInstance().getNotes(procName);
			notesRichTextBox.Font = ProcessWatcher.getInstance().getFont(procName);
		}

		private void stopWatchingButton_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure you want to stop watching and keeping\nnotes on this process?", "Confirm", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
			{
				return;
			}

			ProcessWatcher.getInstance().removeFromWatchedProcesses(procName);
			parentMW.removeProcessTab(this);
		}

		private void closeWindowButton_Click(object sender, EventArgs e)
		{
			closeTab();
		}

		public string getData()
		{
			return notesRichTextBox.Text;
		}

		private void renameButton_Click(object sender, EventArgs e)
		{
			ChangeUserProcNameDialog cupnd = new ChangeUserProcNameDialog(userProcName);

			cupnd.ShowDialog();

			if(cupnd.Changed)
			{
				userProcName = cupnd.NewName;
				ProcessWatcher.getInstance().setUserProcName(procName, userProcName);
				parentMW.changeProcessTabTitle(procName, userProcName);
			}
		}

		private void fontSettingsButton_Click(object sender, EventArgs e)
		{
			fd = new FontDialog();
			fd.Font = notesRichTextBox.Font;

			if(fd.ShowDialog() == DialogResult.OK)
			{
				notesRichTextBox.Font = fd.Font;
				ProcessWatcher.getInstance().setFont(procName, fd.Font);
			}
		}

		public void closeTab()
		{
			ProcessWatcher.getInstance().setNotes(procName, notesRichTextBox.Text);
			
			parentMW.removeProcessTab(this);
		}
	}
}
