using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevTool
{
	public partial class DevTools : Form
	{
		public DevTools()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			UnPackDD05 unPackDD05  =  new UnPackDD05();
			unPackDD05.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			UnPackDD04 unPackDD04 = new UnPackDD04();
			unPackDD04.Show();
		}
	}
}
