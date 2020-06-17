using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NoteKeeper
{
	class ProcessWatcher
	{
		private static ProcessWatcher instance;
		private static List<ProcessListener> listeners = new List<ProcessListener>();

		// sample process note in settings:
		// <ProcessWatcherNote ProcName="notepad.exe" UserProcName="Notepad">All of the notes go here</ProcessWatcherNote>

		// list of watched for processes
		//private List<Proc> watchedProcs = new List<Proc>();
		private Dictionary<string, Proc> watchedProcs = new Dictionary<string, Proc>();

		private ProcessWatcher()
		{
			loadWatchedProcesses();
		}

		public static ProcessWatcher getInstance()
		{
			if(instance == null)
			{
				instance = new ProcessWatcher();
			}

			return instance;
		}

		// basic plan: get the string of notes, parse notes into processes
		// sample process note in settings:
		// <ProcessWatcherNote ProcName="notepad.exe" UserProcName="Notepad" Font="Microsoft Sans Serif, 8, Regular">All of the notes go here</ProcessWatcherNote>
		private void loadWatchedProcesses()
		{
			string notes = Properties.Settings.Default.notes;

			//MessageBox.Show(notes);

			while (notes != "")
			{
				// returns the index of the space after
				int startIndex = notes.IndexOf("<ProcessWatcherNote") + 20;
				int stopIndex = notes.IndexOf("</ProcessWatcherNote>");

				// get the process info without the tags
				string procInfo = notes.Substring(startIndex, stopIndex - startIndex);

				startIndex = procInfo.IndexOf('"') + 1;
				stopIndex = procInfo.Substring(startIndex).IndexOf('"');

				// save the system defined procName
				string procName = procInfo.Substring(startIndex, stopIndex);

				// save the rest of the process info minus the procName
				procInfo = procInfo.Substring(startIndex + stopIndex + 2);

				startIndex = procInfo.IndexOf('"') + 1;
				stopIndex = procInfo.Substring(startIndex).IndexOf('"');

				string userProcName = procInfo.Substring(startIndex, stopIndex);

				// save the rest of the process info minus the userProcName
				procInfo = procInfo.Substring(startIndex + stopIndex + 2);

				startIndex = procInfo.IndexOf('"') + 1;
				stopIndex = procInfo.Substring(startIndex).IndexOf('"');

				string fontInfo = procInfo.Substring(startIndex, stopIndex);

				string fontName = fontInfo.Substring(0, fontInfo.IndexOf(','));

				fontInfo = fontInfo.Substring(fontInfo.IndexOf(',') + 1);

				float fontSize = float.Parse(fontInfo.Substring(0, fontInfo.IndexOf(',')));

				fontInfo = fontInfo.Substring(fontInfo.IndexOf(',') + 1);

				FontStyle fontStyle = FontStyle.Regular;

				switch (fontInfo)
				{
					case "Bold":
						fontStyle = FontStyle.Bold;
						break;
					case "Italic":
						fontStyle = FontStyle.Italic;
						break;
					case "Underline":
						fontStyle = FontStyle.Underline;
						break;
				}

				Font procFont = new Font(fontName, fontSize, fontStyle);

				// this info should be the notes
				procInfo = procInfo.Substring(startIndex + stopIndex + 2);

				Proc np = new Proc(procName, userProcName, procInfo, procFont);

				addToWatchedProcesses(np);

				// remove the latest retrieved notes and move on
				notes = notes.Substring(notes.IndexOf("</ProcessWatcherNote>") + 21);
			}
		}

		// basic plan: start with a null string, add each watched process to the list
		// essentially recreating the notes string every time
		// sample process note in settings:
		// <ProcessWatcherNote ProcName="notepad.exe" UserProcName="Notepad">All of the notes go here</ProcessWatcherNote>
		public void saveWatchedProcesses()
		{
			string updatedNotes = "";

			foreach(KeyValuePair<string, Proc> entry in watchedProcs)
			{
				updatedNotes +=
					"<ProcessWatcherNote ProcName=\"" +
					entry.Value.procName +
					"\" UserProcName=\"" +
					entry.Value.userProcName +
					"\" Font=\"" + 
					entry.Value.font.Name + ", " + entry.Value.font.Size.ToString() + ", " + entry.Value.font.Style.ToString() +
					"\">" +
					entry.Value.notes +
					"</ProcessWatcherNote>";
			}

			Properties.Settings.Default["notes"] = updatedNotes;
			Properties.Settings.Default.Save();
		}

		public string getNotes(string procName)
		{
			Proc retProc;

			if(watchedProcs.TryGetValue(procName, out retProc))
			{
				return retProc.notes;
			}

			return "";
		}

		public void setNotes(string procName, string notes)
		{
			if (watchedProcs.ContainsKey(procName))
			{
				watchedProcs[procName].notes = notes;
			}
		}

		public Font getFont(string procName)
		{
			Proc retProc;

			if (watchedProcs.TryGetValue(procName, out retProc))
			{
				return retProc.font;
			}

			return new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
		}

		public void setFont(string procName, Font font)
		{
			if (watchedProcs.ContainsKey(procName))
			{
				watchedProcs[procName].font = font;
			}
		}

		public Proc getProc(string procName)
		{
			Proc retProc;

			if(watchedProcs.TryGetValue(procName, out retProc))
			{
				return retProc;
			}

			return null;
		}

		public void setUserProcName(string procName, string newUserProcName)
		{
			Proc retProc;

			if(newUserProcName == "")
			{
				return;
			}

			if(watchedProcs.TryGetValue(procName, out retProc))
			{
				retProc.userProcName = newUserProcName;
			}
		}

		public Proc[] getProcs()
		{
			Proc[] procs = new Proc[watchedProcs.Count];
			watchedProcs.Values.CopyTo(procs, 0);
			return procs;
		}

		public void addToWatchedProcesses(Proc newProc)
		{
			addToWatchedProcesses(newProc.procName, newProc.userProcName, newProc.notes, newProc.font);
		}

		public void addToWatchedProcesses(string newProcName, string userProcName = "", string notes = "", Font font = null)
		{
			if(isWatching(newProcName))
			{
				return;
			}

			if(font == null)
			{
				font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
			}

			Proc newProc = new Proc(newProcName, (userProcName == "" ? newProcName : userProcName), notes, font);

			watchedProcs.Add(newProcName, newProc);
		}

		public bool removeFromWatchedProcesses(string oldProcName)
		{
			if(isWatching(oldProcName))
			{
				stopWatching(oldProcName);
				return true;
			}

			return false;
		}

		public bool isWatching(string procName)
		{
			return watchedProcs.ContainsKey(procName);
		}

		private void stopWatching(string procName)
		{
			watchedProcs.Remove(procName);
		}

		public string getUserProcName(string procName)
		{
			if(watchedProcs.ContainsKey(procName))
			{
				return watchedProcs[procName].userProcName;
			}

			return "";
		}

		public void addProcessListener(ProcessListener pl)
		{
			if(!listeners.Contains(pl))
			{
				listeners.Add(pl);
			}
		}

		public void removeProcessListener(ProcessListener pl)
		{
			listeners.Remove(pl);
		}

		public void processStarted(string procName)
		{
			for(int i = 0; i < listeners.Count; i++)
			{
				listeners[i].processStarted(procName);
			}
		}

		public void processStopped(string procName)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].processStopped(procName);
			}
		}

		public void clearNotes()
		{
			watchedProcs.Clear();
			Properties.Settings.Default["notes"] = "";
			Properties.Settings.Default.Save();
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

		/// <summary>
		/// string containing the user's notes for this proc
		/// </summary>
		public string notes;

		/// <summary>
		/// font that was used for the notes for this proc last
		/// </summary>
		public Font font;

		private static readonly Font defaultFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

		public Proc() : this("", "", "", defaultFont)
		{
			// cut straight to final constructor
		}

		public Proc(string procName) : this(procName, procName, "", defaultFont)
		{
			// cut straight to final constructor
		}

		public Proc(string procName, string userProcName) : this(procName, userProcName, "", defaultFont)
		{
			// cut straight to final constructor
		}

		public Proc(string procName, string userProcName, string notes) : this(procName, userProcName, "", defaultFont)
		{
			// cut straight to final constructor
		}

		public Proc(string procName, string userProcName, string notes, Font font)
		{
			this.procName = procName;
			this.userProcName = userProcName;
			this.notes = notes;
			this.font = font;
		}

		public override string ToString()
		{
			return "procName: " + procName + ", userProcName: " + userProcName + ", notes: " + notes + ", font: " + font.ToString();
		}
	}
}
