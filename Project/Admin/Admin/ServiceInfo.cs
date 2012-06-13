using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Admin
{
    public partial class ServiceInfo : Form
    {
        public ServiceInfo()
        {
            InitializeComponent();
        }

        private void userCardID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ServiceInfo_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(returnMain)).Start();
            Close();
        }

        private void returnMain()
        {
            MainPage mainPage = new MainPage();
            mainPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userCardID.Text.Length == 0 || userCardID.Text == null)
            {
                MessageBox.Show("请输入卡号", "警告", MessageBoxButtons.OK);
            }
        }
    }
}
