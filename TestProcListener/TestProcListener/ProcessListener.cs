using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeper
{
	interface ProcessListener
	{
		void processStarted(string procName);
		void processStopped(string procName);
	}
}
