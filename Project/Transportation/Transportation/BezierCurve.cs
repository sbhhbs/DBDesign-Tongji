using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.IO;

namespace Transportation
{
    class BezierCurve
    {
        List<Bezier> beziers = new List<Bezier>();

        double pos;

        public BezierCurve()
        {
            pos = 0.0;
            this.beziers = new List<Bezier>();
        }

        public void addBezier(Bezier bezier)
        {
            beziers.Add(bezier);
        }

        public BezierCurve(List<Bezier> beziers)
        {
            pos = 0.0;
            this.beziers = beziers;
        }

        public Point move()
        {
            int i = (int)pos;

            double count = pos - i;

            if (i > 0 && count - 0.1 < 0)
            {
                i--;
                count = 1;
            }

            Bezier bezier = beziers.ElementAt(i);

            pos += Bezier.stepLength * 10;

            return bezier.getPoint(count);
        }

        public Boolean isEnd()
        {
            return (pos - beziers.Count) > Bezier.stepLength;
        }

        public static Hashtable getCurvesFromFile(String filePath)
        {
            Hashtable table = new Hashtable();

            StreamReader sr = new StreamReader(filePath);

            String line;

            Boolean isStart = true;
            Boolean isStartAndPoints = false;

            BezierCurve bezierCurve = new BezierCurve();

            Point startPoint = new Point();
            Point endPoint = new Point();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.ElementAt(0) == '#')
                {
                    if (isStart)
                    {
                        isStart = false;
                    }
                    else
                    {
                        table.Add(new Line(startPoint, endPoint), bezierCurve);
                        startPoint = new Point();
                        endPoint = new Point();
                        bezierCurve = new BezierCurve();

                        Line tempLine = new Line(startPoint, endPoint);

                        Boolean fuck = table.ContainsKey(tempLine);
                    }

                    isStartAndPoints = true;
                }
                else if (isStartAndPoints)
                {
                    isStartAndPoints = false;

                    int i = 0;

                    while (line[i] != ' ') i++;

                    startPoint = Utility.getPointFromString(line.Substring(0, i));

                    endPoint = Utility.getPointFromString(line.Substring(i + 1));
                }
                else
                {
                    Bezier bezier = getBezierFromString(line);

                    bezierCurve.addBezier(bezier);
                }
            }

            sr.Close();

            return table;
        }

        private static Bezier getBezierFromString(String input)
        {
            Bezier bezier = new Bezier();

            int start = 0;
            int end = 0;

            while (start < input.Length)
            {
                while (end < input.Length && input[end] != ' ') end++;

                bezier.addPoint(Utility.getPointFromString(input.Substring(start, end - start)));

                end = start = end + 1;
            }

            return bezier;
        }


    }
}
