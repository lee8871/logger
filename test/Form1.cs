using Sl.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			Program.log6 = new LoggerToRTB(this.LogTextRTB) {
				word_color_pair = new (string word, Color color)[] {
					("【崩溃", Color.DarkRed),
					("【错误", Color.Red),
					("【警告", Color.DarkViolet),
					("【消息", Color.MidnightBlue),
					("【电机过热", Color.Firebrick),
				},
				Cc = Program.log1
			};
			Program.log6.LogLine($"【消息】这条消息会写入RichTextBox");
			Program.log6.LogLine($"【错误】发生控制错误");
			Program.log6.LogLine($"【警告】电机堵转");
			Program.log6.LogLine($"【电机过热】电机持续堵转导致过热");
		}
	}
}
