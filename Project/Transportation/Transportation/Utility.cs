using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.IO;

namespace Transportation
{
    class Utility
    {
        public static Point getPointFromString(String input)
        {
            Point point = new Point();

            int i = 0;

            while (input[i] != ',') i++;

            point.X = int.Parse(input.Substring(0, i));
            point.Y = int.Parse(input.Substring(i + 1));

            return point;
        }
    }

    public class Line
    {
        Point startPos;
        Point endPos;

        public Line(Point startPos, Point endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }

        public System.Drawing.Point StartPos
        {
            get { return startPos; }
            set { startPos = value; }
        }
       
        public System.Drawing.Point EndPos
        {
            get { return endPos; }
            set { endPos = value; }
        }
    }

    public class Route
    {
        private int pos = 0;
        private List<Line> lines;

        public Route()
        {
            lines = new List<Line>();
        }

        public void addLine(Line line)
        {
            lines.Add(line);
        }

        public Line moveToNextLine()
        {
            if (pos >= lines.Count)
                return null;
            else
                return lines.ElementAt(pos++);
        }

        public static Route routeFromFile(String filePath)
        {
            Route route = new Route();

            StreamReader sr = new StreamReader(filePath);

            int count = 0;

            Point firstPoint = new Point();
            Point secondPoint = new Point();

            while (!(sr.EndOfStream))
            {
                String line = sr.ReadLine();

                if (count == 0)
                {
                    firstPoint = Utility.getPointFromString(line);
                    count = 1;
                }
                else if (count == 1)
                {
                    secondPoint = Utility.getPointFromString(line);

                    route.addLine(new Line(firstPoint, secondPoint));

                    firstPoint = secondPoint;

                    count = 1;
                }

            }

            sr.Close();

            return route;
        }
    }
}
