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
	public partial class ChangeUserProcNameDialog : Form
	{
		private bool userChangedName = false;

		public bool Changed
		{
			get
			{
				return userChangedName;
			}
		}

		public string NewName
		{
			get
			{
				return newNameTextBox.Text;
			}
		}

		public ChangeUserProcNameDialog()
		{
			InitializeComponent();

			StartPosition = FormStartPosition.CenterParent;
		}

		public ChangeUserProcNameDialog(string oldProcName)
		{
			InitializeComponent();

			oldNameLabel.Text = oldProcName;

			StartPosition = FormStartPosition.CenterParent;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			trySetSuccess();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			userChangedName = false;
			this.Close();
		}

		private void newNameTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				trySetSuccess();
			}
		}

		/// <summary>
		/// Attempts to set the userChangedName variable, and closes the form
		/// </summary>
		private void trySetSuccess()
		{
			if (NewName != "")
			{
				userChangedName = true;
			}

			this.Close();
		}
	}
}
