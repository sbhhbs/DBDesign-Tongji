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
        private bool isDown = false;
        private Point currentPoint;

        private int mapX = 0;
        private int mapY = 0;

        public TransportationView()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true); 
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                int dx = Control.MousePosition.X - currentPoint.X;
                int dy = Control.MousePosition.Y - currentPoint.Y;

                currentPoint.X = Control.MousePosition.X;
                currentPoint.Y = Control.MousePosition.Y;

                Image image = map.Image;

                Graphics graphics = map.CreateGraphics();

                if (mapX + dx < map.Width - image.Width)
                    mapX = map.Width - image.Width;
                else if (mapX + dx >= 0)
                    mapX = 0;
                else
                    mapX += dx;

                if (mapY + dy < map.Height - image.Height)
                    mapY = map.Height - image.Height;
                else if (mapY + dy >= 0)
                    mapY = 0;
                else
                    mapY += dy;

                graphics.DrawImage(image, mapX, mapY);
                graphics.Dispose();
            }
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;

            currentPoint.X = Control.MousePosition.X;
            currentPoint.Y = Control.MousePosition.Y;

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.map.Cursor = Cursors.SizeAll;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private void TransportationView_Load(object sender, EventArgs e)
        {

        }

        private void map_Click(object sender, EventArgs e)
        {

        }

        private void map_Click_1(object sender, EventArgs e)
        {

        }
    }
}
