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
using System.Threading;


namespace Transportation
{
    public partial class RailSystem : Form
    {
        private bool isDown = false;
        private bool isMiddleDown = false;
        private bool isMoved = false;

        private Point currentPoint;
        private Point orgPoint;

        private Route testRoute;

        private BezierRoute bezierRoute = new BezierRoute();

        private int mapX = 0;
        private int mapY = 0;        

        private Point currentPlace;

        private Hashtable pointTable = new Hashtable();
        private Hashtable routeTable = new Hashtable();

        public RailSystem() : base()
        {
            InitializeComponent();

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

            routeTable = BezierCurve.getCurvesFromFile("..\\..\\assets\\bezier_points.txt");

            testRoute = Route.routeFromFile("..\\..\\assets\\test_route.txt");

            Line tempLine;

            while ((tempLine = testRoute.moveToNextLine()) != null)
                bezierRoute.addBezierCurve(getBezierCurveFromHash(tempLine));
            
        }

        private BezierCurve getBezierCurveFromHash(Line line)
        {
            foreach (System.Collections.DictionaryEntry item in routeTable)
            {
                Line temp = (Line)item.Key;

                if (temp.StartPos.X == line.StartPos.X && temp.StartPos.Y == line.StartPos.Y && temp.EndPos.X == line.EndPos.X && temp.EndPos.Y == line.EndPos.Y)
                    return (BezierCurve)item.Value;
            }

            return null;
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

            
            if (!isMoved && currentPlace.X != -1 && currentPlace.Y != -1)
            {
                Rail_Dialog dialog = new Rail_Dialog();

                DialogResult dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.Yes)
                    startPos.Text = (string)pointTable[currentPlace];
                else if (dialogResult == DialogResult.No)
                    endPos.Text = (string)pointTable[currentPlace];

                dialog.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = map.CreateGraphics();

            Bitmap bitmap = new Bitmap(map.Image, map.Image.Width, map.Image.Height);
            bitmap.SetResolution(graphics.DpiX, graphics.DpiY);

            graphics.DrawImage(bitmap, mapX, mapY);

            graphics.Dispose();
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            orgPoint.X = map.Left;
            orgPoint.Y = map.Top;

            orgPoint = PointToScreen(orgPoint);

            if (isDown || isMiddleDown)
            {
                isMoved = true;

                Point mapPoint = new Point(map.Left, map.Top);

                mapPoint = PointToScreen(mapPoint);

                Point middlePoint = new Point(( 2 * mapPoint.X + map.Width) / 2, (2 * mapPoint.Y + map.Height) / 2);

                Rectangle rect = new Rectangle(mapPoint.X, mapPoint.Y, map.Width, map.Height);

                Cursor.Clip = rect;

                int dx = Control.MousePosition.X - currentPoint.X;
                int dy = Control.MousePosition.Y - currentPoint.Y;

                currentPoint.X = Control.MousePosition.X;
                currentPoint.Y = Control.MousePosition.Y;

                Graphics graphics = map.CreateGraphics();

                Image image = map.Image;
                

                if (isDown)
                {
                    if (mapX + dx < map.Width - image.Width)
                    {
                        mapX = map.Width - image.Width;
                       
                    }
                    else if (mapX + dx >= 0)
                    {
                        mapX = 0;
                      
                    }
                    else
                    {
                        mapX += dx;
                
                    }

                    if (mapY + dy < map.Height - image.Height)
                    {
                        mapY = map.Height - image.Height;
                  
                    }
                    else if (mapY + dy >= 0)
                    {
                        mapY = 0;
             
                    }
                    else
                    {
                        mapY += dy;
             
                        
                    }
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
                Bitmap bitmap = new Bitmap(map.Image, map.Image.Width, map.Image.Height);
                bitmap.SetResolution(graphics.DpiX, graphics.DpiY);

                graphics.DrawImage(bitmap, mapX, mapY);
                graphics.Dispose();
            }
            else
            {
                Point temp = new Point(Control.MousePosition.X, Control.MousePosition.Y);

                temp.X = temp.X - orgPoint.X - mapX;
                temp.Y = temp.Y - orgPoint.Y - mapY;

                 Console.WriteLine("Current relative Pos : " + temp.X + "," + temp.Y);

                for (int i = -2; i != 3; i++)//放大鼠标的检测范围
                    for (int j = -2; j != 3; j++)
                    {
                        if (pointTable.Contains(new Point(temp.X + i, temp.Y + j)))
                        {
                            currentPlace = new Point(temp.X + i, temp.Y + j);
                            Cursor = Cursors.Hand;
                            return;
                        }
                    }

                Cursor = Cursors.Default;
                currentPlace = new Point(-1, -1);
            }
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {

            isMoved = false;

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

        private void button_Return_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();

            mainPage.Show();
        }

        private void RouteTestButton_Click(object sender, EventArgs e)
        {
            routeTestRun();
        }

        private void routeTestRun()
        {
            while (bezierRoute.isEnd())
            {
                Thread.Sleep(100);

                Point nextPos = bezierRoute.move();

                if (nextPos.X == 0 && nextPos.Y == 0)
                    return;
                
                PositionMark.Left = ( nextPos.X * 2 + map.Left * 2 - PositionMark.Width ) / 2;
                PositionMark.Top =  ( nextPos.Y * 2 + map.Top * 2 - PositionMark.Height ) / 2;
            }

        }

    }
  
}
