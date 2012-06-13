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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void go_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerService service = new CustomerService();
            service.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if ((textBoxUserName.Text == null) || (textBoxPassword.Text == null))
            {
                MessageBox.Show("用户名或密码不可为空哦！", "出错", MessageBoxButtons.OK);
            }
            else if ((textBoxUserName.Text.Length == 0) || (textBoxPassword.Text.Length == 0))
            {
                MessageBox.Show("用户名或密码不可为空哦！", "出错", MessageBoxButtons.OK);
            }
            else
            {
                new Thread(new ThreadStart(logIn)).Start();
                this.Close();
            }
        }

        private void logIn()
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            serviceInfo.ShowDialog();

            // TODO: Add The Client Part
        }
    }
}
