using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Bezier_Test
{
    class BezierCurve
    {
        List<Bezier> beziers = new List<Bezier>();

        double pos;

        public BezierCurve(List<Bezier> beziers)
        {
            pos = 0.0;
            this.beziers = beziers;
        }

        public Point move()
        {
            int i = (int)pos;

            double count = pos - i;

            if (i > 0 && count == 0)
            {
                i--;
                count = 1;
            }

            Bezier bezier = beziers.ElementAt(i);

            pos += Bezier.stepLength;

            return bezier.getPoint(count);
        }

        public Boolean isEnd()
        {
            return pos == (double)(beziers.Count + Bezier.stepLength);
        }
    }
}
