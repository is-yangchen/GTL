using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeviceUtils;
using Instrument;

namespace VirtialDevices
{
    public partial class ErrorMessageForm : Form
    {
        private String Msg;

        public ErrorMessageForm(String msg)
        {
            InitializeComponent();
            Msg = msg;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorMessageForm_Load(object sender, EventArgs e)
        {
            errorTextBox.Text = Msg;
        }
    }
}
