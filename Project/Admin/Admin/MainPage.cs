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
            Services service = new Services();
            service.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(logIn)).Start();
            this.Close();
        }

        private void logIn()
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            serviceInfo.ShowDialog();

            // TODO: Add The Client Part
        }
    }
}
