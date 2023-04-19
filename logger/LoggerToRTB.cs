using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sl.Log {
	public class LoggerToRTB : Logger {

		static public (string word, Color color)[] default_word_color_pair = {
		("崩溃", Color.DarkRed),
		("错误", Color.Red),
		("警告", Color.DarkViolet),
		("消息", Color.MidnightBlue),
		};
		static public (string word, Color color)[] success_word_color_pair = {
		("成功", Color.DarkGreen),
		("失败", Color.DarkRed),
		("错误", Color.DarkOrange),
		("警告", Color.DarkViolet),
		("消息", Color.MidnightBlue),
		};

		public (string word, Color color)[] word_color_pair = default_word_color_pair;
		public RichTextBox LogRTB;
		public LoggerToRTB(RichTextBox LogRTB) {
			this.LogRTB = LogRTB;
		}
		public Logger Cc { get; set; }

		public void LogLine(string str) {
			addLog(str);
			Cc?.LogLine(str);
		}
		void addLog(string log) {
			if (LogRTB.InvokeRequired) {
				var d = new Action<string>(this.addLog);
				LogRTB.Invoke(d, log);
				return;
			}
			if (LogRTB.IsDisposed) return; 
			LogRTB.SelectionStart = LogRTB.TextLength;
			LogRTB.SelectionLength = 0;
			LogRTB.ScrollToCaret();

			Color select_color = default;
			string[] sts = log.Split('】');
			for (int i = 0; i < sts.Length - 1; i++) {
				select_color = word_color_pair.FirstOrDefault(pair => pair.word == sts[i].Substring(1)).color;
				if (select_color != default) {
					break;
				}
				if (sts[i].Substring(0, 1) != "【") {
					break;
				}
			}
			if (select_color == default) {
				select_color = Color.Black;
			}
			LogRTB.SelectionColor = select_color;
			LogRTB.AppendText(log + '\n');

			LogRTB.SelectionStart = LogRTB.TextLength;
			LogRTB.SelectionLength = 0;
			LogRTB.ScrollToCaret();


		}
	}
}
