using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slzd.Log {
	public interface Logger {
		Logger Cc { get; }//抄送给另一个日志器
		void LogLine(string str);
	}
}
