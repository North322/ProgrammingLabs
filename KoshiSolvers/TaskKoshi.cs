using System;

namespace KoshiSolvers
{
    public class TaskKoshi
    {
        private double y0;
        private double t0;
        private double t;
        private double h;

        public double Y0 { get { return y0; } set { y0 = value; } }

        public double T0 { get { return t0; } set { t0 = value; } }

        public double T
        {
            get { return t; }
            set
            {
                if (value >= t0)
                    throw new ArgumentException("Right border must be greater than left one");
                t = value;
            }
        }
        public double H
        {
            get { return h; }
            set
            {
                if (h <= 0)
                    throw new ArgumentException("Step can't have zero or negative value");
                h = value;
            }
        }

        // Constructors
        public TaskKoshi(double _Y0, double _T0, double _T, double _H)
        {
            try
            {
                y0 = _Y0;
                t0 = _T0;
                t = _T;
                h = _H;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public double CountFunctionValue(double Xi, double Yi)
        {
            return Math.Sin((Xi + Yi) * Math.PI / 180);
        }
    }
}
