using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace Transportation
{
    public partial class RailSystem : Form
    {
        private bool isDown = false;
        private bool isMiddleDown = false;

        private Point currentPoint;
        private Point orgPoint;

        private int mapX = 0;
        private int mapY = 0;

        private Hashtable pointTable = new Hashtable(); 

        public RailSystem() : base()
        {
            InitializeComponent();

            orgPoint.X = map.Left;
            orgPoint.Y = map.Top;

            orgPoint = PointToScreen(orgPoint);

            StreamReader f2 = new StreamReader("..\\..\\assets\\points.txt", System.Text.Encoding.GetEncoding("gb2312"));

            String temp;
            while (!f2.EndOfStream)
            {
                Point tempPoint = new Point(0, 0);

                temp = f2.ReadLine();
                int start = 0;
                int end = 0;
                while (temp[++end] != ',') ;

                tempPoint.X = int.Parse(temp.Substring(start, end - start));

                start = end + 1;
                end = start;

                while (temp[++end] != ' ') ;

                tempPoint.Y = int.Parse(temp.Substring(start, end - start));

                start = end + 1;

                String location = temp.Substring(start);

                pointTable.Add(tempPoint, location);

            }

            f2.Close();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            map.Cursor = Cursors.SizeAll;
        }

        private void RailSystem_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            
            Cursor.Clip = Screen.PrimaryScreen.Bounds;
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = map.CreateGraphics();
            Image image = map.Image;

            graphics.DrawImage(image, mapX, mapY);
            graphics.Dispose();
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown || isMiddleDown)
            {
                Point mapPoint = new Point(map.Left, map.Top);

                mapPoint = PointToScreen(mapPoint);

                Point middlePoint = new Point(( 2 * mapPoint.X + map.Width) / 2, (2 * mapPoint.Y + map.Height) / 2);

                Rectangle rect = new Rectangle(mapPoint.X, mapPoint.Y, map.Width, map.Height);

                Cursor.Clip = rect;

                int dx = Control.MousePosition.X - currentPoint.X;
                int dy = Control.MousePosition.Y - currentPoint.Y;

                currentPoint.X = Control.MousePosition.X;
                currentPoint.Y = Control.MousePosition.Y;

                Image image = map.Image;

                Graphics graphics = map.CreateGraphics();

                if (isDown)
                {
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
                }
                else if (isMiddleDown)
                {
                    if (dx > 0 && mapX - dx >= map.Width - image.Width + 10)
                    {
                        mapX = mapX - dx;
                    }
                    else if (dx < 0 && mapX - dx <= 0)
                    {
                        mapX = mapX - dx;
                    }

                    if (dy > 0 && mapY - dy >= map.Height - image.Height + 10)
                    {
                        mapY = mapY - dy;
                    }
                    else if (dy < 0 && mapY - dy <= 0)
                    {
                        mapY = mapY - dy;
                    }

                    if (currentPoint.X < middlePoint.X && currentPoint.Y == middlePoint.Y)
                        Cursor = Cursors.PanWest;
                    else if (currentPoint.X > middlePoint.X && currentPoint.Y == middlePoint.Y)
                        Cursor = Cursors.PanEast;
                    else if (currentPoint.Y < middlePoint.Y && currentPoint.X == middlePoint.X)
                        Cursor = Cursors.PanNorth;
                    else if (currentPoint.Y > middlePoint.Y && currentPoint.X == middlePoint.X)
                        Cursor = Cursors.PanSouth;
                    else if (currentPoint.Y > middlePoint.Y && currentPoint.X > middlePoint.X)
                        Cursor = Cursors.PanSE;
                    else if (currentPoint.Y > middlePoint.Y && currentPoint.X < middlePoint.X)
                        Cursor = Cursors.PanSW;
                    else if (currentPoint.Y < middlePoint.Y && currentPoint.X > middlePoint.X)
                        Cursor = Cursors.PanNE;
                    else if (currentPoint.Y < middlePoint.Y && currentPoint.X < middlePoint.X)
                        Cursor = Cursors.PanNW;

                }

                graphics.DrawImage(image, mapX, mapY);
                graphics.Dispose();
            }
            else
            {
                Point temp = new Point(Control.MousePosition.X, Control.MousePosition.Y);

                temp.X = temp.X - orgPoint.X - mapX;
                temp.Y = temp.Y - orgPoint.Y - mapY;

                Console.WriteLine("Current relative Pos : " + temp.X + "," + temp.Y);

                for (int i = -2; i != 3; i++)
                    for (int j = -2; j != 3; j++)
                    {
                        if (pointTable.Contains(new Point(temp.X + i, temp.Y + j)))
                        {
                            Cursor = Cursors.Hand;
                            return;
                        }
                    }

                Cursor = Cursors.Default;
            }
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    isDown = true;

                    currentPoint.X = Control.MousePosition.X;
                    currentPoint.Y = Control.MousePosition.Y;

                    break;
                case MouseButtons.Middle:
                    isDown = false;
                    isMiddleDown = !isMiddleDown;

                    currentPoint.X = Control.MousePosition.X;
                    currentPoint.Y = Control.MousePosition.Y;

                    break;

                default:
                    break;
            }
        }

        private void map_Click(object sender, EventArgs e)
        {

        }

        private void map_Paint()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
