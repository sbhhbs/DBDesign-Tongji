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
    public partial class Rail_Dialog : Form
    {
        // HashTable pointTable[] = new HashTable;;
        public Rail_Dialog()
        {
            InitializeComponent();
        }

        private void button_In_Click(object sender, EventArgs e)
        {
            //    StartPosition = pointTable[currentPoint];
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public object currentPoint { get; set; }

        private void button_Out_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Rail_Dialog_Load(object sender, EventArgs e)
        {

        }
       

    }
}
