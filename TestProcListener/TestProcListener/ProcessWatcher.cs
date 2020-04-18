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

		// list of watched for processes
		private List<Proc> watchedProcs = new List<Proc>();

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

		public bool addToWatchedProcesses(string newProcName, string userProcName = "")
		{
			if(!alreadyWatching(newProcName))
			{
				Proc newProc = new Proc(newProcName, (userProcName == "" ? newProcName : userProcName));

				watchedProcs.Add(newProc);
				return true;
			}

			return false;
		}

		public bool removeFromWatchedProcesses(string oldProcName)
		{
			if(alreadyWatching(oldProcName))
			{
				stopWatching(oldProcName);
				return true;
			}

			return false;
		}

		private bool alreadyWatching(string procName)
		{
			for(int i = 0; i < watchedProcs.Count; i++)
			{
				if(watchedProcs[i].procName == procName)
				{
					return true;
				}
			}

			return false;
		}

		private void stopWatching(string procName)
		{
			for (int i = 0; i < watchedProcs.Count; i++)
			{
				if (watchedProcs[i].procName == procName)
				{
					watchedProcs.RemoveAt(i);
					return;
				}
			}
		}
	}

	public class Proc
	{
		/// <summary>
		/// string containing the system name of the process
		/// </summary>
		public string procName;

		/// <summary>
		/// string containing the user-given name of the process
		/// </summary>
		public string userProcName;

		public Proc() : this("", "")
		{

		}

		public Proc(string procName, string userProcName)
		{
			this.procName = procName;
			this.userProcName = userProcName;
		}
	}
}
