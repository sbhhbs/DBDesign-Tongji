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
    public partial class ServiceCardLost : Form
    {
        public ServiceCardLost()
        {
            InitializeComponent();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void charge_Click(object sender, EventArgs e)
        {
            ServiceRecharge serviceRechage = new ServiceRecharge();
            serviceRechage.Show();
            this.Hide();
        }

        private void balanceQuery_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
            this.Hide();
        }

        private void change_Click(object sender, EventArgs e)
        {
            ServiceChange serviceChange = new ServiceChange();
            serviceChange.Show();
            this.Hide();
        }

        private void historyQuery_Click(object sender, EventArgs e)
        {
            ServiceHistory serviceHistory = new ServiceHistory();
            serviceHistory.Show();
            this.Hide();
        }

        private void ServiceCardLost_Load(object sender, EventArgs e)
        {

        }

    }
}
