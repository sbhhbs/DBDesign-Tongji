using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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

            new Thread(new ThreadStart(showRailSystem)).Start();
            Close();
        }

        private void showRailSystem() 
        {
            RailSystem railSystem = new RailSystem();
            railSystem.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(back)).Start();
            Close();
        }

        private void back()
        {
            new TransportationMainPage().ShowDialog();
        }


    }
}
