using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace KoshiSolvers
{
    class TaskKoshi
    {
        // Properties
        public Func<double, double, double> Func { get; set; }

        public double Y0 { get; set; }

        public double T0 { get; set; }

        public double T
        {
            get { return T; }
            set
            {
                if (value >= T0)
                    throw new ArgumentException("Right border must be greater than left one");
                T = value;
            }
        }
        public double H
        {
            get { return H; }
            set
            {
                if (H <= 0)
                    throw new ArgumentException("Step can't have zero or negative value");
                H = value;
            }
        }

        // Constructors
        public TaskKoshi(double _Y0, double _T0, double _T, double _H)
        {
            try
            {
                Y0 = _Y0;
                T0 = _T0;
                T = _T;
                H = _H;
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
