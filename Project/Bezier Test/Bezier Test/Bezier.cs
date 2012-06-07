using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Bezier_Test
{
    // 二阶 Bezier 曲线类

    class Bezier
    {
        private Point p1;
        private Point p2;
        private Point p3;

        public static double stepLength = 0.01;

        public System.Drawing.Point P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        
        public System.Drawing.Point P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public System.Drawing.Point P3
        {
            get { return p3; }
            set { p3 = value; }
        }

        public Bezier()
        {

        }

        public Bezier(Point p1, Point p2, Point p3)
        {
            this.p1.X = p1.X;
            this.p1.Y = p1.Y;

            this.p2.X = p2.X;
            this.p2.Y = p2.Y;

            this.p3.X = p3.X;
            this.p3.Y = p3.Y;
        }

        public void draw(Graphics graphics, Bitmap bmp, int offsetX, int offsetY)
        {
            graphics.Clear(Color.White);
            for (double i = 0; i <= 1; i += stepLength)
            {
                int x = PointPostion(i, PointPostion(i, p1.X, p2.X), PointPostion(i, p2.X, p3.X));
                int y = PointPostion(i, PointPostion(i, p1.Y, p2.Y), PointPostion(i, p2.Y, p3.Y));

                bmp.SetPixel(x, y, Color.White);
            }

            graphics.DrawImage(bmp, -offsetX, -offsetY);

            graphics.Flush();
        }

        public Point getPoint(double count)
        {
            int x = PointPostion(count, PointPostion(count, p1.X, p2.X), PointPostion(count, p2.X, p3.X));
            int y = PointPostion(count, PointPostion(count, p1.Y, p2.Y), PointPostion(count, p2.Y, p3.Y));

            return new Point(x, y);
        }

        private int PointPostion(double t, int x1, int x2)
        {
            return (int)((double)((1 - t) * x1 + t * x2));
        }

        public String writeString()
        {
            return p1.X + "," + p1.Y + " " + p2.X + "," + p2.Y + " " + p3.X + "," + p3.Y; 
        }
    }
}
