using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace NoteKeeper
{
	public partial class MainWindow : Form, ProcessListener
	{
		List<ProcessTab> openTabs = new List<ProcessTab>();
		/// <summary>
		/// The current list of processes that the mainwindow is keeping track of
		/// </summary>
		List<string> currentProcessesListed = new List<string>();
		static bool isListing = false;
		Dispatcher dispatcher;
		Task checker;

		ManagementEventWatcher startWatch, stopWatch;

		public MainWindow()
		{
			InitializeComponent();

			procListView.Columns[1].Width = 245;
			procListView.Columns[2].Width = 380;

			listProcesses();

			checkForNewProcesses();

			ProcessWatcher.getInstance().addProcessListener(this);

			ManagementEventWatcher startWatch = new ManagementEventWatcher(  new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
			startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
			//startWatch.Start();

			ManagementEventWatcher stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
			stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
			//stopWatch.Start();

			// set the dispatcher to this thread
			dispatcher = Dispatcher.CurrentDispatcher;

			// create an action to perform in a separate thread
			Action<object> action = (object obj) =>
			{
				// the separate thread is 
				checkProcs();
			};

			// create a task so that the action can run in a separate thread
			checker = new Task(action, "alpha");

			checker.Start();
		}

		// this method is meant to run in a separate thread forever
		private void checkProcs()
		{
			// forever
			while(true)
			{
				// if the process list has changed
				if(processListHasChanged())
				{
					// have the parent list the processes
					dispatcher.Invoke(listProcesses);
				}

				// to avoid taking all of the cpu cycles, sleep this thread 
				// (which should be the child thread) for 100 milliseconds
				Thread.Sleep(1000);
			}
		}

		private static void stopWatch_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string procName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			ProcessWatcher.getInstance().processStopped(procName);
			//MessageBox.Show(procName);
		}

		private static void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string procName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			ProcessWatcher.getInstance().processStarted(procName);
			//MessageBox.Show(procName);
		}

		private void checkForNewProcesses()
		{
			Process[] currentProcs = Process.GetProcesses();

			bool listChanged = false;

			for(int i = 0; i < currentProcs.Length; i++)
			{
				if(ProcessWatcher.getInstance().isWatching(currentProcs[i].ProcessName))
				{
					if(!isTabOpen(currentProcs[i].ProcessName))
					{
						addProcessTab(currentProcs[i].ProcessName, ProcessWatcher.getInstance().getUserProcName(currentProcs[i].ProcessName), false);
					}
				}
			}
		}

		// used by the child thread to determine if the list has changed,
		// which in turn is used to tell the parent that the list needs 
		// to be updated
		private bool processListHasChanged()
		{
			// get a snapshot of the currently running processes
			Process[] procs = Process.GetProcesses();

			// get the snapshots currently being watched in the ProcessWatcher
			Proc[] currentlyWatchedProcs = ProcessWatcher.getInstance().getProcs();

			// the processes we're currently trying to list
			List<string> currentProcesses = new List<string>();

			// loop through the current snapshot list of processes
			for (int i = 0; i < procs.Length; i++)
			{
				if(procs[i].MainWindowTitle == Text)
				{
					continue;
				}

				// if the MainWindowTitle of the process is not "", that means
				// it should be a visible window
				if (procs[i].MainWindowTitle != "")
				{
					// return true only if it's not currently listed, and it's not 
					// currently on the currentProcessesListed list
					if (!isListed(procs[i].ProcessName) && !currentProcessesListed.Contains(procs[i].ProcessName))
					{
						return true;
					}

					currentProcesses.Add(procs[i].ProcessName);
				}
			}

			// go through the old list of processes and cull the ones no longer running
			for (int i = 0; i < currentProcessesListed.Count; i++)
			{
				if (!currentProcesses.Contains(currentProcessesListed[i]))
				{
					return true;
				}
			}

			return false;
		}

		void listProcesses()
		{
			// checks a static bool to see if we're already trying to list the processes
			if(!isListing)
			{
				isListing = true;
			}
			else
			{
				return;
			}

			// get a snapshot of the currently running processes
			Process[] procs = Process.GetProcesses();

			// get the snapshots currently being watched in the ProcessWatcher
			Proc[] currentlyWatchedProcs = ProcessWatcher.getInstance().getProcs();

			// the processes we're currently trying to list
			List<string> currentProcesses = new List<string>();

			// loop through the current snapshot list of processes
			for (int i = 0; i < procs.Length; i++)
			{
				if (procs[i].MainWindowTitle == Text)
				{
					continue;
				}

				// if the MainWindowTitle of the process is not "", that means
				// it should be a visible window
				if (procs[i].MainWindowTitle != "")
				{
					// this is just a visual representation of whether the 
					// process is being watched to be displayed on the listview
					string isBeingWatched = "No";

					// check to see if the process is already being watched
					if (ProcessWatcher.getInstance().isWatching(procs[i].ProcessName))
					{
						// if it is, set isBeingWatched to true/yes
						isBeingWatched = "Yes";

						// since it's already being watched, we should have a previous 
						// Proc object for it. Find that and open a new tab with it
						for (int j = 0; j < currentlyWatchedProcs.Length; j++)
						{
							if(currentlyWatchedProcs[j].procName == procs[i].ProcessName)
							{
								if(!isTabOpen(currentlyWatchedProcs[j].procName))
								{
									addProcessTab(currentlyWatchedProcs[j].procName, currentlyWatchedProcs[j].userProcName, false);
								}
							}
						}
					}

					// add a process to the listView only if it's not currently listed, and it's not 
					// currently on the currentProcessesListed list
					if(!isListed(procs[i].ProcessName) && !currentProcessesListed.Contains(procs[i].ProcessName))
					{
						ListViewItem lvi = new ListViewItem(new string[] { procs[i].Id.ToString(), procs[i].ProcessName, procs[i].MainWindowTitle, isBeingWatched });

						procListView.Items.Add(lvi);

						currentProcessesListed.Add(procs[i].ProcessName);
					}

					currentProcesses.Add(procs[i].ProcessName);
				}
			}

			// go through the old list of processes and cull the ones no longer running
			for (int i = 0; i < currentProcessesListed.Count; i++)
			{
				if(!currentProcesses.Contains(currentProcessesListed[i]))
				{
					removeListItem(currentProcessesListed[i]);
					currentProcessesListed.RemoveAt(i);
				}
			}

			isListing = false;
		}

		private void removeListItem(string procName)
		{
			for(int i = 0; i < procListView.Items.Count; i++)
			{
				if(procListView.Items[i].SubItems[1].Text == procName)
				{
					procListView.Items.RemoveAt(i);
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			//startWatching();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			//procListView.Items.Clear();
			listProcesses();
		}

		private void addProcsButton_Click(object sender, EventArgs e)
		{
			addProcs();
		}

		private void addProcs()
		{
			// if at least 1 process was selected
			if (procListView.SelectedIndices.Count > 0)
			{
				// loop through all of the selected processes, and go through the AddProcessForm
				// to add them to the Process Watcher
				for (int i = 0; i < procListView.SelectedIndices.Count; i++)
				{
					string procName = procListView.Items[procListView.SelectedIndices[i]].SubItems[1].Text;
					string userProcName = procListView.Items[procListView.SelectedIndices[i]].SubItems[2].Text;

					AddProcessForm newadf = new AddProcessForm(
						procName,
						userProcName,
						this);

					newadf.ShowDialog(this);
					newadf.Dispose();
					newadf.Close();
				}
			}
		}

		private void procListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			
		}

		public void addProcessTab(string procName, string userProcName, bool goToNewTab)
		{
			try
			{
				if (!isTabOpen(procName))
				{
					this.BeginInvoke((Action)(() =>
					{
						ProcessTab newTab = new ProcessTab(procName, userProcName, this);
						TabPage newPage = new TabPage(userProcName);
						newTab.Dock = DockStyle.Fill;
						newPage.Controls.Add(newTab);
						tabControl1.Controls.Add(newPage);

						openTabs.Add(newTab);

						for (int i = 0; i < procListView.Items.Count; i++)
						{
							if (procListView.Items[i].SubItems[1].Text == procName)
							{
								procListView.Items[i].SubItems[3].Text = "Yes";
							}
						}

						if(goToNewTab)
						{
							tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(newPage);
						}
					}));
				}
			}
			catch(Exception e)
			{
				//MessageBox.Show(e.Message + "\n" + e.StackTrace);
			}
		}

		private bool isTabOpen(string procName)
		{
			for(int i = 0; i < openTabs.Count; i++)
			{
				if(openTabs[i].procName == procName)
				{
					return true;
				}
			}

			return false;
		}

		private bool isListed(string procName)
		{
			try
			{
				for (int i = 0; i < procListView.Items.Count; i++)
				{
					if (procListView.Items[i].SubItems[1].Text == procName)
					{
						return true;
					}
				}
			}
			catch(Exception e)
			{
				// this is a workaround for while developing
				// returning true to avoid complications
				return false;// true;
			}

			return false;
		}

		public void removeProcessTab(ProcessTab pt)
		{
			// loop through the tab pages and find the one with the given ProcessTab;
			// then remove it
			for(int i = 1; i < tabControl1.TabCount; i++)
			{
				if(tabControl1.TabPages[i].Controls.Contains(pt))
				{
					tabControl1.TabPages.RemoveAt(i);
					openTabs.Remove(pt);
				}
			}

			if(!ProcessWatcher.getInstance().isWatching(pt.procName))
			{
				for (int i = 0; i < procListView.Items.Count; i++)
				{
					if(procListView.Items[i].SubItems[1].Text == pt.procName)
					{
						procListView.Items[i].SubItems[3].Text = "No";
					}
				}
			}
		}

		public void changeProcessTabTitle(string procName, string newUserProcName)
		{
			for (int i = 1; i < tabControl1.TabPages.Count; i++)
			{
				bool foundToChange = false;

				for (int j = 0; j < tabControl1.TabPages[i].Controls.Count; j++)
				{
					if (tabControl1.TabPages[i].Controls[j] is ProcessTab)
					{
						if(((ProcessTab)tabControl1.TabPages[i].Controls[j]).procName == procName)
						{
							foundToChange = true;
							break;
						}
					}
				}

				if(foundToChange)
				{
					tabControl1.TabPages[i].Text = newUserProcName;
					tabControl1.Refresh();
				}
			}
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			closeAll();
		}

		private void closeAll()
		{
			for (int i = 1; i < tabControl1.TabPages.Count; i++)
			{
				for (int j = 0; j < tabControl1.TabPages[i].Controls.Count; j++)
				{
					if (tabControl1.TabPages[i].Controls[j] is ProcessTab)
					{
						((ProcessTab)tabControl1.TabPages[i].Controls[j]).closeTab();
						i--;
					}
				}
			}
			
			ProcessWatcher.getInstance().saveWatchedProcesses();
		}

		public void processStarted(string procName)
		{
			listProcesses();
		}

		private void clearNotesButton_Click(object sender, EventArgs e)
		{
			if(tabControl1.TabPages.Count <= 1)
			{
				return;
			}

			if(MessageBox.Show("Are you sure you want to clear all notes?\n" +
				"This will remove all of your notes, even for\n" +
				"processes not currently listed.", 
				"Confirm", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
			{
				ProcessWatcher.getInstance().clearNotes();
				closeAll();
			}
		}

		private void procListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			addProcs();
		}

		public void processStopped(string procName)
		{
			//MessageBox.Show(procName);
			listProcesses();
		}
	}
}