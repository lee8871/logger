using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slzd.Log {
	public class TagLogger : Logger {
		public TagLogger(string tag, Logger base_logger, Logger cc = null) {
			Tag = tag;
			Base_Logger = base_logger;
			Cc = cc;
		}

		public Logger Cc { get; }

		public string Tag { get; }
		public Logger Base_Logger { get; }

		public void LogLine(string str) {
			Base_Logger.LogLine($"【{Tag}】{str}");
			Cc?.LogLine(str);
		}
	}
}
