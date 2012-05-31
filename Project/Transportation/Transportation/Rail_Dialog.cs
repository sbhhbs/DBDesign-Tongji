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
            this.DialogResult = DialogResult.Cancel;
        }

        public object currentPoint { get; set; }

        private void button_Out_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        
        }
        
    }
      class Factor
    {
        private static Dialog dialog = null;

        public static Dialog createDialog()
        {
            if(dialog == null)
            {
                dialog = new Dialog();
            }
            return dialog;
        }
    }
    class Dialog:Form
    {
        Rail_Dialog rail_dialog = new Rail_Dialog();
        public Dialog()
        {
           //Rail_Dialog rail_dialog = new Rail_Dialog();
            //rail_dialog.show();
        }
        public void show() 
        {
            rail_dialog.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            rail_dialog.Hide();
        }
        public void hide()
        {
            rail_dialog.Hide();
        }
            
    }
}
