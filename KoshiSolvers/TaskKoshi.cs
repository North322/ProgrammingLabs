﻿using System;

namespace KoshiSolvers
{
    public class InitialValueProblem
    {
        // Class fields
        private double t;
        private double h;
        
        // Properties
        public double Y0 { get; }

        public double T0 { get; }

        public double T
        {
            get { return t; }
            set
            {
                if (value < T0)
                    throw new ArgumentException("Right border must be greater than left one");
                t = value;
            }
        }
        public double H
        {
            get { return h; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Step can't have zero or negative value");
                h = value;
            }
        }

        // Constructors
        public InitialValueProblem(double _Y0, double _T0, double _T, double _H)
        {
            Y0 = _Y0;
            T0 = _T0;
            T = _T;
            H = _H;
        }

        //TODO 
        // Methods
        public double CountFunctionValue(double Xi, double Yi)
        {
            return Math.Sin((Xi + Yi) * Math.PI / 180);
        }
    }
}
