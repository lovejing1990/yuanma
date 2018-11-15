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
			UnPackDD05 wind =  new UnPackDD05();
			wind.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			UnPackDD04 wind = new UnPackDD04();
			wind.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Coordinate wind = new Coordinate();
			wind.Show();
		}
	}
}
