using System;
using System.Windows.Forms;
using LocalCommons.Utilities;
//using LocalCommons.Cryptography;

namespace DevTool
{
	public partial class UnPackDD04 : Form
	{
		public UnPackDD04()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 压缩
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Conversion_Click(object sender, EventArgs e)
		{
			string msg1 = SourceTextBox.Text;

			if (msg1.Length <= 8)
			{
				ResultTextBox.Text = "原文长度必须大于8";
				return;
			}

			string msg2 = msg1;//.Substring(4, msg1.Length - 4);

			byte[] cipherbytes = Utility.StringToByteArray(msg2);

			cipherbytes = LocalCommons.Compression.Compressing.Compress(cipherbytes);
			//cipherbytes =   Compress.BytesDeflater(cipherbytes);

			string msg3 = Utility.ByteArrayToString(cipherbytes);

			ResultTextBox.Text = msg3;
		}

		/// <summary>
		/// 解压缩
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string msg1 = ResultTextBox.Text;

			if (msg1.Length <= 8)
			{
				ResultTextBox.Text = "原文长度必须大于8";
				return;
			}

			string msg2 = msg1;//.Substring(8, msg1.Length - 8);

			byte[] cipherbytes = Utility.StringToByteArray(msg2);
			//cipherbytes = Compress.ByteInflater(cipherbytes);
			cipherbytes = LocalCommons.Compression.Compressing.Decompress(cipherbytes);
			string msg3 = Utility.ByteArrayToString(cipherbytes);

			SourceTextBox.Text = msg3;
		}
	}
}
