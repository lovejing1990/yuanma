using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalCommons.Utilities;
namespace DevTool
{
	public partial class Coordinate : Form
	{
		public Coordinate()
		{
			InitializeComponent();
		}

		private void buttonX1_Click(object sender, EventArgs e)
		{
			string hex = textBoxXHex.Text;
			try
			{
				float flo = Helpers.ConvertX(Utility.StringToByteArray(hex));
				textBoxX.Text = flo.ToString();
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
			
		}

		private void buttonX2_Click(object sender, EventArgs e)
		{
			string hex = textBoxX.Text;
			try
			{
				byte[] flo = Helpers.ConvertX(Convert.ToSingle(hex));
				textBoxXHex.Text = Utility.ByteArrayToString(flo);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void buttonY1_Click(object sender, EventArgs e)
		{
			string hex = textBoxYHex.Text;
			try
			{
				float flo = Helpers.ConvertY(Utility.StringToByteArray(hex));
				textBoxY.Text = flo.ToString();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void buttonY2_Click(object sender, EventArgs e)
		{
			string hex = textBoxY.Text;
			try
			{
				byte[] flo = Helpers.ConvertY(Convert.ToSingle(hex));
				textBoxYHex.Text = Utility.ByteArrayToString(flo);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void buttonZ1_Click(object sender, EventArgs e)
		{
			string hex = textBoxZHex.Text;
			try
			{
				float flo = Helpers.ConvertZ(Utility.StringToByteArray(hex));
				textBoxZ.Text = flo.ToString();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void buttonZ2_Click(object sender, EventArgs e)
		{
			string hex = textBoxZ.Text;
			try
			{
				byte[] flo = Helpers.ConvertZ(Convert.ToSingle(hex));
				textBoxZHex.Text = Utility.ByteArrayToString(flo);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}
	}
}
