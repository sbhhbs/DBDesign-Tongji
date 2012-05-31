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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void railSystemButton_Click(object sender, EventArgs e)
        {
            RailSystem railSystem = new RailSystem();
            railSystem.Show();
            this.Hide();
        }

        private void transportSystemButton_Click(object sender, EventArgs e)
        {
            TransportationView transportation = new TransportationView();
            transportation.Show();
            this.Hide();
        }
    }
}
