using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl.Log {
	public class TimerLogger : Logger {
		public TimerLogger(Logger base_logger, Logger cc = null) {
			Base_Logger = base_logger;
			Cc = cc;
		}

		public Logger Cc { get; }
		public Logger Base_Logger { get; }

		public void LogLine(string str) {
			Base_Logger.LogLine($"【{DateTime.Now:hh:mm:ss:fff}】{str}");
			Cc?.LogLine(str);
		}
	}
}
