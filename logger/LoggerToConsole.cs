using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl.Log {
	public class LoggerToConsole: Logger {
		public Logger Cc { get; }
		public LoggerToConsole(Logger cc = null) {
			Cc = cc;
		}
		static object Console_locker = new object();

		public readonly (string word, ConsoleColor color)[] word_color_pair = {
			("【崩溃", ConsoleColor.DarkRed),
			("【错误", ConsoleColor.Red), 
			("【警告", ConsoleColor.Yellow), 
			("【消息", ConsoleColor.Cyan)};

		public virtual void LogLine(string str) {
			ConsoleColor select_color = default;
			string[] sts = str.Split('】');
			for(int i =0;i< sts.Length - 1; i++) {
				select_color = word_color_pair.FirstOrDefault(pair => pair.word == sts[i]).color;
				if (select_color != default) {
					break;
				}
				if(sts[i].Substring(0,1)!= "【") {
					break;
				}
			}

			if (select_color == default) {
				select_color = ConsoleColor.White;
			}
			if(select_color == ConsoleColor.DarkRed) {

			}
			lock (Console_locker) {
				ConsoleColor temp = Console.ForegroundColor;
				Console.ForegroundColor = select_color;
				Console.WriteLine(str);
				Console.ForegroundColor = temp;
			}
			Cc?.LogLine(str);
		}
	}
}
