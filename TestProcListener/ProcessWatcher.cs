using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProcListener
{
	class ProcessWatcher
	{
		private static ProcessWatcher instance;

		// sample process note in settings:
		// <ProcessWatcherNote ProcName="notepad.exe" UserProcName="Notepad">All of the notes go here</ProcessWatcherNote>

		// list of watched for processes by process name, not user defined name
		private List<string> watchedProcesses = new List<string>();

		private ProcessWatcher()
		{

		}

		public static ProcessWatcher getInstance()
		{
			if(instance == null)
			{
				instance = new ProcessWatcher();
			}

			return instance;
		}

		public bool addToWatchedProcesses(string newProcName)
		{
			if(!watchedProcesses.Contains(newProcName))
			{
				watchedProcesses.Add(newProcName);
				return true;
			}

			return false;
		}

		public bool removeFromWatchedProcesses(string oldProcName)
		{
			if(watchedProcesses.Contains(oldProcName))
			{
				watchedProcesses.Remove(oldProcName);
				return true;
			}

			return false;
		}
	}
}
