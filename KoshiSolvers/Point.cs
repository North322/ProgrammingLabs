using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(double _X, double _Y)
        {
            X = _X;
            Y = _Y;
        }
    }
}

