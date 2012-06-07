using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Transportation
{
    class BezierRoute
    {
        private List<BezierCurve> bezierCurves;

        private int pos;

        public BezierRoute()
        {
            bezierCurves = new List<BezierCurve>();
            pos = 0;
        }

        public void addBezierCurve(BezierCurve bezierCurve)
        {
            bezierCurves.Add(bezierCurve);
        }

        public Point move()
        {
            if (bezierCurves.ElementAt(pos).isEnd())
                pos++;

            if (!isEnd())
                return new Point(0, 0);

            return bezierCurves.ElementAt(pos).move();
        }

        public Boolean isEnd()
        {
            return pos < bezierCurves.Count;
        }
    }
}
