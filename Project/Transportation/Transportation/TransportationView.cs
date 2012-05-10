using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transportation
{
    public partial class TransportationView : Form
    {
        public TransportationView()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {


        }

        private void TransportrationView_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
