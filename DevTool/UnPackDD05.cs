using LocalCommons.Cryptography;
using LocalCommons.Utilities;
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
    public partial class UnPackDD05 : Form
    {
        public UnPackDD05()
        {
            InitializeComponent();
        }

        private void Conversion_Click(object sender, EventArgs e)
        {
            string msg1 = SourceTextBox.Text;

            if (msg1.Length <= 8)
            {
                ResultTextBox.Text = "原文长度必须大于8";
                return;
            }

            string msg2 = msg1.Substring(8, msg1.Length - 8);

            byte[] cipherbytes = Utility.StringToByteArray(msg2);
            cipherbytes = Encrypt.StoCEncrypt(cipherbytes);
            string msg3 = Utility.ByteArrayToString(cipherbytes);
            msg2 = msg3;
            msg3 = msg1.Substring(0, 8) + msg3;
            ResultTextBox.Text = msg3;
        }

        private void SourceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
    }
}
