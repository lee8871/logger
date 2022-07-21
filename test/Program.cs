using Slzd.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test {
	internal static class Program {


		public static Logger log0;
		public static Logger log1;
		public static Logger log2;
		public static Logger log3;
		public static Logger log4;
		public static Logger log5;
		public static Logger log6;
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() {

			//如果你在这里报错，请把路径改成你要存放日志的文件夹。
			log0 = new LoggerToFile($"D:/SRB调试日志/log0{DateTime.Now:yyyyMMdd-HH-mm-ss}.md");
			log0.LogLine($"【消息】初始完成了。");

			log1 = new LoggerToConsole();
			log1.LogLine($"【消息】初始完成了。");

			log2 = new LoggerToConsole(log0);
			log2.LogLine($"【消息】这条消息被log2记录后，还会抄送给log0");

			log3 = new LoggerToConsole(new LoggerToFile($"D:/SRB调试日志/log3{DateTime.Now:yyyyMMdd-HH-mm-ss}.md"));
			log3.LogLine($"【消息】这条消息会直接被两个日志记录器记录");

			log4 = new TimerLogger(log2);
			log4.LogLine($"【消息】这条消息会被加上时间标记");

			log5 = new TagLogger("电机模块", log4);
			log5.LogLine($"【消息】这条消息会被加上“电机模块”标签");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
