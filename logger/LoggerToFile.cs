using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl.Log {
	public class LoggerToFile : Logger {
		public string Log_File { get; }
		public Logger Cc { get; }

		StreamWriter logFs = null;
		public LoggerToFile(string log_file, Logger cc = null) {
			Cc = cc;
			Log_File = log_file;
			logFs = new StreamWriter(Log_File, false, Encoding.UTF8);
			logFs.AutoFlush = true;
		}

		public virtual void LogLine(string str) {
			lock (logFs) {
				logFs.WriteLine(str);
			}
			Cc?.LogLine(str);
		}

	}
}
