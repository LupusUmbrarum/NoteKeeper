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

namespace TestProcListener
{
	public partial class MainWindow : Form
	{
		ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
		ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");

		List<Process> procs = new List<Process>();

		public MainWindow()
		{
			InitializeComponent();

			Process[] currentProcs = Process.GetProcesses();

			for(int i = 0; i < currentProcs.Length; i++)
			{
				procs.Add(currentProcs[i]);
			}

			//processStartEvent.EventArrived += new EventArrivedEventHandler(processStartEvent_EventArrived);
			//processStopEvent.EventArrived += new EventArrivedEventHandler(processStopEvent_EventArrived);

			//richTextBox1.AppendText("There are currently " + procs.Count + " processes running.\nStarted listening...");

			TreeNode tn0 = new TreeNode("Windows");
			TreeNode tn1 = new TreeNode("Linux");
			

			treeView1.Nodes.Add(tn0);
			treeView1.Nodes.Add(tn1);
			treeView1.EndUpdate();

			tryCheck();
		}

		private void startWatching()
		{
			while(true)
			{
				checkForNewProcesses();
			}
		}

		private async void tryCheck()
		{
			while(true)
			{
				checkForNewProcesses();
				checkForLostProcesses();
				await Task.Delay(100);
			}
		}

		private void checkForLostProcesses()
		{
			Process[] currentProcs = Process.GetProcesses();
			Process[] watchedProcs = procs.ToArray();

			for(int i = 0; i < watchedProcs.Length; i++)
			{
				bool shouldRemove = true;

				for(int j = 0; j < currentProcs.Length; j++)
				{
					if(watchedProcs[i].Id == currentProcs[j].Id)
					{
						shouldRemove = false;
						break;
					}
				}

				if(shouldRemove)
				{
					procs.Remove(watchedProcs[i]);
				}
			}
		}

		private void checkForNewProcesses()
		{
			Process[] currentProcs = Process.GetProcesses();
			Process[] watchedProcs = procs.ToArray();

			bool listChanged = false;

			for(int i = 0; i < currentProcs.Length; i++)
			{
				bool shouldAddToList = true;

				for(int j = 0; j < watchedProcs.Length; j++)
				{
					if(currentProcs[i].Id == watchedProcs[j].Id)
					{
						shouldAddToList = false;
						break;
					}
				}

				if(shouldAddToList)
				{
					procs.Add(currentProcs[i]);
					listChanged = true;
				}
			}

			if(listChanged)
			{
				//richTextBox1.Text = "";
				//richTextBox1.Text = procs.Count + " procs being watched";
				//richTextBox1.Text += "\n" + currentProcs.Length + " procs running\n";

				for(int i = 0; i < procs.Count; i++)
				{
					//richTextBox1.Text += procs[i].ProcessName + "\n";
				}
			}
		}

		void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string procName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			string procID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

			//richTextBox1.AppendText(procName + " " + procID + " has started");
			MessageBox.Show("hello there");
		}

		void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string procName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			string procID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

			//richTextBox1.AppendText(procName + " " + procID + " has ended");
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			startWatching();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(treeView1.SelectedNode != null)
			{
				//MessageBox.Show(treeView1.SelectedNode.Text);
				ProcessWatcher.getInstance().addToWatchedProcesses(treeView1.SelectedNode.Text);
			}
		}
	}
}
