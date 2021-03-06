﻿using System;
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
using System.Net;
using Newtonsoft.Json;
using System.Web;


namespace Transportation
{
    public partial class RailSystem : Form
    {
        private bool isDown = false;
        private bool isMiddleDown = false;
        private bool isMoved = false;
        private bool isAnimating = false;

        private Point currentPoint;
        private Point orgPoint;

        private Route testRoute;

        private bool isEnd = false;

        private BezierRoute bezierRoute = new BezierRoute();

        private List<string> routeList = new List<string>();

        private Point userPos = new Point();

        private int mapX = 0;
        private int mapY = 0;

        private int currentPosIndex = -1;

        private Point currentPlace;

        private Hashtable pointTable = new Hashtable();
        private Hashtable routeTable = new Hashtable();

        private Bitmap bitmap;

        public RailSystem() : base()
        {
            InitializeComponent();

            StreamReader f2 = new StreamReader("..\\..\\assets\\points.txt", System.Text.Encoding.GetEncoding("gb2312"));

            Graphics graphics = map.CreateGraphics();

            bitmap = new Bitmap(map.Image, map.Image.Width, map.Image.Height);
            bitmap.SetResolution(graphics.DpiX, graphics.DpiY);

            graphics.Dispose();


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

        private List<Point> getPointFromList(List<string> pointList)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i != pointList.Count; i++)
            {
                Point point = new Point();
                point = getPointFromTable(pointList.ElementAt(i));
                points.Add(point);
            }

            return points;
        }

        private Point getPointFromTable(string name)
        {
            foreach (System.Collections.DictionaryEntry item in pointTable)
            {
                Point temp = (Point)item.Key;
                string stationName = (string)item.Value;

                if (name.Equals(stationName))
                {
                    return temp;
                }
            }

            return new Point(0, 0);
        }

        private BezierCurve getBezierCurveFromHash(Line line)
        {
            foreach (System.Collections.DictionaryEntry item in routeTable)
            {
                Line temp = (Line)item.Key;

                if (temp.StartPos.X == line.StartPos.X && temp.StartPos.Y == line.StartPos.Y && temp.EndPos.X == line.EndPos.X && temp.EndPos.Y == line.EndPos.Y)
                {
                    BezierCurve bezierCurve = (BezierCurve)item.Value;
                    bezierCurve.setMode(BezierCurve.FrontMove);
                    // bezierRoute.setMode(BezierCurve.FrontMove);
                    return bezierCurve;
                }
                else if (temp.StartPos.X == line.EndPos.X && temp.StartPos.Y == line.EndPos.Y && temp.EndPos.X == line.StartPos.X && temp.EndPos.Y == line.StartPos.Y)
                {
                    BezierCurve bezierCurve = (BezierCurve)item.Value;
                    bezierCurve.setMode(BezierCurve.BackMove);
                    // bezierRoute.setMode(BezierCurve.BackMove);
                    return bezierCurve;          
                }
            }

            return null;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            map.Cursor = Cursors.SizeAll;
        }

        private void RailSystem_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
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

            if (isAnimating)
            {
                SolidBrush brush = new SolidBrush(Color.Black);

                graphics.FillEllipse(brush, new Rectangle(userPos.X, userPos.Y, 10, 10));
            }

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
            if (isAnimating)
                return;

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
            new Thread(new ThreadStart(back)).Start();
            isEnd = true;
            Close();
        }

        private void back()
        {
            new MainPage().ShowDialog();
        }

        private void RouteTestButton_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(routeTestRun)).Start();
            isAnimating = true;
        }

        private void routeTestRun()
        {
            currentPosIndex = 0;

            while (bezierRoute.isEnd() && !isEnd)
            {
                Thread.Sleep(100);

                Point nextPos = bezierRoute.move();

                if (nextPos.X == 0 && nextPos.Y == 0)
                {
                    isAnimating = false;
                    endTrip();
                    currentPosIndex = -1;
                    return;
                }

                Console.WriteLine("mapPos");
                Console.WriteLine(mapX);
                Console.WriteLine(mapY);

                userPos.X = nextPos.X;
                userPos.Y = nextPos.Y;

                Console.WriteLine("userPos");
                Console.WriteLine(userPos.X);
                Console.WriteLine(userPos.Y);


                Point mapPosExpected = nextPos;//fuck...do i have to assign a value here?
                Point pointOffset = nextPos;//fuck...do i have to assign a value here?
                pointOffset.X = 0;
                pointOffset.Y = 0;


                mapPosExpected.X = (userPos.X - map.Width / 2);
                mapPosExpected.Y = (userPos.Y - map.Height / 2);


                //out of boundary
                if (mapPosExpected.X < 0)
                {
                    pointOffset.X = mapPosExpected.X;
                    mapPosExpected.X = 0;
                }
                else if (mapPosExpected.X + map.Width > bitmap.Width)
                {
                    pointOffset.X = mapPosExpected.X - (bitmap.Width - (mapPosExpected.X + map.Width));
                    mapPosExpected.X = bitmap.Width - map.Width;
                }

                if (mapPosExpected.Y < 0)
                {
                    pointOffset.Y = mapPosExpected.Y;
                    mapPosExpected.Y = 0;
                }
                else if (mapPosExpected.Y + map.Height > bitmap.Height)
                {
                    pointOffset.Y = mapPosExpected.Y - (bitmap.Height - (mapPosExpected.Y + map.Height));
                    mapPosExpected.Y = bitmap.Height - map.Height;
                }



                mapX = -mapPosExpected.X;
                mapY = -mapPosExpected.Y;


                //now is picture-box base position

                userPos.X = map.Width / 2 - 5 + pointOffset.X;
                userPos.Y = map.Height / 2 - 5 + pointOffset.Y;

                Graphics graphics = map.CreateGraphics();

                graphics.DrawImage(bitmap, mapX, mapY);

                SolidBrush brush = new SolidBrush(Color.Black);

                graphics.FillEllipse(brush, new Rectangle(userPos.X, userPos.Y, 10, 10));

                graphics.Dispose();

                if (bezierRoute.IsOnStation())
                {
                    currentPosIndex++;
                    GoOut.Enabled = true;
                    Thread.Sleep(1000);
                    bezierRoute.setOnStation();
                    GoOut.Enabled = false;
                }
            }   
        }

        private void map_Paint(object sender, PaintEventArgs e)
        {
            // base.OnPaint(e);


        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            List<string> route = new List<string>();
            route = getRoute();
            routeList = route;
            if (route.Count != 0)
            {
                startTrip();

                bezierRoute.clear();

                Route singleRoute = getRouteFromPoints(getPointFromList(route));

                Line tempLine;

                while ((tempLine = singleRoute.moveToNextLine()) != null)
                    bezierRoute.addBezierCurve(getBezierCurveFromHash(tempLine));

                new Thread(new ThreadStart(routeTestRun)).Start();
                isAnimating = true;
            }
        }

        private bool endTrip()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/OutStation?cardId=" + HttpUtility.UrlEncodeUnicode(ResourceClass.card_id) + "&&stationName=" + HttpUtility.UrlEncodeUnicode(routeList[currentPosIndex]) + "&&price=6.0");
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();

            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = @responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));
            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private bool startTrip()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/InStation?cardId=" + HttpUtility.UrlEncodeUnicode(ResourceClass.card_id) + "&&stationName=" + HttpUtility.UrlEncodeUnicode(startPos.Text));
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();

            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = @responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));
            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private Route getRouteFromPoints(List<Point> points)
        {
            Route route = new Route();

            Point firstPoint = new Point();
            Point secondPoint = new Point();

            firstPoint = points.First();

            for (int i = 1; i != points.Count; i++)
            {
                secondPoint = points.ElementAt(i);
                Line line = new Line(firstPoint, secondPoint);
                route.addLine(line);

                firstPoint = secondPoint;
            }

            return route;
            
        }

        private List<string> getRoute()
        {
            List<string> route = new List<string>();

            if (startPos.Text.Length == 0 || startPos.Text == null || endPos.Text.Length == 0 || endPos.Text == null)
            {
                MessageBox.Show("请输入卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return route;
            }

            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/FindRoute?startStationName=" + HttpUtility.UrlEncodeUnicode(startPos.Text) + "&&endStationName=" + HttpUtility.UrlEncodeUnicode(endPos.Text));
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;
   
            WebResponse response = requestToServer.GetResponse();

            StreamReader responseReader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Unicode);
            string replyFromServer = @responseReader.ReadToEnd();

            route = JsonConvert.DeserializeObject<List<string>>(replyFromServer);

            return route;
        }

        private void GoOut_Click(object sender, EventArgs e)
        {
            isEnd = true;
            isAnimating = false;
            endTrip();
            // TODO: Add the go out part.
        }
    }
  
}
