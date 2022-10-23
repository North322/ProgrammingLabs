using System.Collections.Generic;
using System;

namespace KoshiSolvers
{
    public abstract class Solver
    {
        // Class fields 
        private BehaviorOfSolver behaviour;
        private string name;
    
        // Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("SolverName shouldn't be empty, null, or white space!");
                name = value;
            }
        }

        public BehaviorOfSolver Behavior { get; set; }

        // Constructors
        public Solver(string _Name, BehaviorOfSolver _Behaviour)
        {
            
            Behavior = _Behaviour;
            Name = _Name;
        } 
        // Methods
        public abstract List<Point> Solve(InitialValueProblem Task);
    }
}
