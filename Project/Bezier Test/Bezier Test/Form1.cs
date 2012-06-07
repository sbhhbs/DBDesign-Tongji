using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bezier_Test
{
    public partial class Form1 : Form
    {

        private List<Bezier> beziers = new List<Bezier>();

        private Boolean isDown = false;

        private Point p1 = new Point();
        private Point p2 = new Point();
        private Point p3 = new Point();

        private Point startPoint;
        private Point endPoint;

        private Point midPoint;

        private Point currentPos;

        private Boolean isMiddle = false;

        private double halfDis = 3.0;

        private double currentDistance = 0.0;

        private int offsetX = 0;
        private int offsetY = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BezierContainer_Click(object sender, EventArgs e)
        {

        }

        private void BezierContainer_MouseDown(object sender, MouseEventArgs e)
        {
            beziers.Clear();

            isDown = true;

            p1.X = Control.MousePosition.X;
            p1.Y = Control.MousePosition.Y;

            p1 = PointToClient(p1);

            p1.X -= BezierContainer.Left;
            p1.Y -= BezierContainer.Top;

            startPoint = p1;


            currentPos = p1;
        }

        private void BezierContainer_MouseMove(object sender, MouseEventArgs e)
        {
            Point temp = new Point();

            temp.X = Control.MousePosition.X;
            temp.Y = Control.MousePosition.Y;

            temp.X -= BezierContainer.Left;
            temp.Y -= BezierContainer.Top;
            
            temp = PointToClient(temp);

            // System.Console.Out.WriteLine("Pos : " + temp.X + "," + temp.Y);


            if (isDown)
            {
                Point mapPoint = new Point(BezierContainer.Left, BezierContainer.Top);

                mapPoint = PointToScreen(mapPoint);

                Rectangle rect = new Rectangle(mapPoint.X, mapPoint.Y, BezierContainer.Width, BezierContainer.Height);

                Cursor.Clip = rect;

                currentDistance += distanceTo(temp, currentPos);

                if (currentDistance >= halfDis && !isMiddle)
                {
                    midPoint = new Point(temp.X, temp.Y);
                    isMiddle = true;
                }
                else if (currentDistance >= 2 * halfDis && isMiddle) 
                {
                    p3 = temp;

                    p2 = getSecondPoint(midPoint, p1, p3);

                    Bezier bezier = new Bezier(p1, p2, p3);

                    currentDistance = 0;

                    p1 = new Point(p3.X, p3.Y);

                    beziers.Add(bezier);

                    isMiddle = false;
                }

                currentPos = temp;
            }
        }

        private double distanceTo(Point org, Point dest)
        {
            return Math.Sqrt((org.X - dest.X) * (org.X - dest.X) + (org.Y - dest.Y) * (org.Y - dest.Y));
        }

        private Point getSecondPoint(Point middlePoint, Point p1, Point p3)
        {
            Point p2 = new Point(0, 0);

            p2.X = 2 * (midPoint.X - (int)(double)(0.25 * (p1.X + p3.X)));
            p2.Y = 2 * (midPoint.Y - (int)(double)(0.25 * (p1.Y + p3.Y)));

            return p2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write();
        }

        private void BezierContainer_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            Cursor.Clip = Screen.PrimaryScreen.Bounds;

            if (isMiddle)
            {
                Point temp = new Point();

                temp.X = Control.MousePosition.X;
                temp.Y = Control.MousePosition.Y;

                temp.X -= BezierContainer.Left;
                temp.Y -= BezierContainer.Top;

                temp = PointToClient(temp);

                p3 = temp;

                p2 = getSecondPoint(midPoint, p1, p3);

                Bezier bezier = new Bezier(p1, p2, p3);

                currentDistance = 0;

                isMiddle = false;
            }

            endPoint = new Point(Control.MousePosition.X, Control.MousePosition.Y);

            endPoint = PointToClient(endPoint);

            endPoint.X -= BezierContainer.Left;
            endPoint.Y -= BezierContainer.Top;

            Graphics graphics = BezierContainer.CreateGraphics();

            Bitmap bm = new Bitmap(BezierContainer.Image, BezierContainer.Image.Width, BezierContainer.Image.Height);
            bm.SetResolution(graphics.DpiX, graphics.DpiY);

            for (int i = 0; i != beziers.Count; i++)
            {
                beziers.ElementAt(i).draw(graphics, bm, offsetX, offsetY);
            }

            graphics.Dispose();

        }

        private void write()
        {
            StreamWriter sw = new StreamWriter("C:\\bezier_points.txt", true);

            sw.WriteLine("#Start");
            sw.WriteLine(startPoint.X + "," + startPoint.Y + " " + endPoint.X + "," + endPoint.Y);

            for (int i = 0; i != beziers.Count; i++)
            {
                sw.WriteLine(beziers.ElementAt(i).writeString());
            }

            sw.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = BezierContainer.CreateGraphics();

            Bitmap bitmap = new Bitmap(BezierContainer.Image, BezierContainer.Image.Width, BezierContainer.Image.Height);
            bitmap.SetResolution(graphics.DpiX, graphics.DpiY);

            for (int i = 0; i != beziers.Count; i++)
            {
                beziers.ElementAt(i).draw(graphics, bitmap, offsetX, offsetY);
            }

            graphics.Dispose();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Left"))
            {
                offsetX = offsetX - BezierContainer.Width / 2 < 0 ? 0 : offsetX - BezierContainer.Width / 2;
                Invalidate(null, false);
            }
            else if (e.KeyCode.ToString().Equals("Right"))
            {
                offsetX = offsetX + BezierContainer.Width / 2 > BezierContainer.Image.Width - BezierContainer.Width ? BezierContainer.Image.Width - BezierContainer.Width : 
                    offsetX + BezierContainer.Width / 2;
                Invalidate(null, false);
            }
            else if (e.KeyCode.ToString().Equals("Up"))
            {
                offsetY = offsetY - BezierContainer.Width / 2 < 0 ? 0 : offsetY - BezierContainer.Width / 2;
                Invalidate(null, false);
            }
            else if (e.KeyCode.ToString().Equals("Down"))
            {
                offsetY = offsetY + BezierContainer.Width / 2 > BezierContainer.Image.Height - BezierContainer.Height ? BezierContainer.Image.Height - BezierContainer.Height :
                    offsetY + BezierContainer.Width / 2;
                Invalidate(null, false);
            }

            
        }
    }
}
