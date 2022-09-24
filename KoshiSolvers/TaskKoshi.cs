using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace KoshiSolvers
{
    class TaskKoshi
    {
        private Func<double,double,double> func;
        private double y0;
        private double t0;
        private double t;
        private double h;
        
        // Properties
        public Func<double, double, double> Func {
            get { return func;}
            set { func = value; }
        } 
        public double Y0
        {
            get { return y0; }
            set { y0 = value; }
        }

        public double T0
        {
            get { return t0; }
            set { t0 = value; }
        }
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
            get
            {
                if (h <= 0)
                    throw new ArgumentException("Step can't have zero or negative value");
                return h;
            }
            set { h = value; }
        }

        // Constructors
        public TaskKoshi(double _Y0, double _T0, double _T, double _H)
        {
            try
            {
                t0 = _Y0;
                t0 = _T0;
                t = _T;
                h = _H;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        // func should receive two double x y values and return f(x,y) 
        public double CountFunctionValue(double Xi, double Yi)
        {
            return func(Xi, Yi);
        }
    }
}
