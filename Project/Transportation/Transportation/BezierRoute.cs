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

        private int mode = BezierCurve.FrontMove;

        private bool isOnStation = false;

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

        public void setOnStation()
        {
            isOnStation = false;
        }

        public bool IsOnStation()
        {
            return isOnStation;
        }

        public void setMode(int mode)
        {
            this.mode = mode;
            if (mode == BezierCurve.BackMove)
            {
                pos = bezierCurves.Count - 1;
                bezierCurves.Last().setMode(mode);
            }
            else if (mode == BezierCurve.FrontMove)
            {
                pos = 0;
                bezierCurves.First().setMode(mode);
            }
        }

        public Point move()
        {
            if (bezierCurves.ElementAt(pos).isEnd())
            {
                if (mode == BezierCurve.FrontMove)
                    pos++;
                else if (mode == BezierCurve.BackMove)
                    pos--;

                if (!isEnd())
                    return new Point(0, 0);

                isOnStation = true;
                bezierCurves.ElementAt(pos).setMode(mode);
            }

           

            return bezierCurves.ElementAt(pos).move();
        }

        public Boolean isEnd()
        {
            if (mode == BezierCurve.FrontMove)
                return pos < bezierCurves.Count;
            else if (mode == BezierCurve.BackMove)
                return pos >= 0;

            return false;
        }
    }
}
