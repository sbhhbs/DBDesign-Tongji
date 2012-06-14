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

        private List<int> mode = new List<int>();

        private bool isOnStation = false;

        private int pos;

        public BezierRoute()
        {
            bezierCurves = new List<BezierCurve>();
            pos = 0;
        }

        public void clear()
        {
            bezierCurves.Clear();
            mode.Clear();
            isOnStation = false;
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
            this.mode.Add(mode);
            int i = this.mode.Count - 1;
            if (mode == BezierCurve.BackMove)
            {
                bezierCurves.ElementAt(i).setMode(mode);
            }
            else if (mode == BezierCurve.FrontMove)
            {
                bezierCurves.ElementAt(i).setMode(mode);
            }
        }

        public Point move()
        {
            if (bezierCurves.ElementAt(pos).isEnd())
            {
                pos++;

                if (!isEnd())
                    return new Point(0, 0);

                isOnStation = true; 
            }

            return bezierCurves.ElementAt(pos).move();
        }

        public Boolean isEnd()
        {
            return pos < bezierCurves.Count;
        }
    }
}
