using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
