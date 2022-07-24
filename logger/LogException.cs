using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl.Log {
	public class LogException {
		readonly Logger logger;
		readonly string log_file;
		public LogException(Logger logger,string logger_file = null) {
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
			this.logger = logger;
			this.log_file = logger_file;
		}
		private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e) {
			logger.LogLine($"【崩溃】任务中捕捉到未观测的异常：\n```\n{e.Exception}\n```");
			if (log_file != null) {
				System.Diagnostics.Process.Start(log_file);
			}
			return;
		}
		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			logger.LogLine($"【崩溃】捕捉到异常：\n```\n{e.ExceptionObject as Exception}\n```");
			if (log_file != null) {
				System.Diagnostics.Process.Start(log_file);
			}
			return;
		}
	}
}
