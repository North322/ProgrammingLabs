using System.Collections.Generic;
using System;

namespace KoshiSolvers
{
    abstract class Solver
    {
        private string name;
        protected BehaviorOfSolver behavior;
        public List<Point> Solution { get; set; }
        public abstract void SolveKoshiTask(TaskKoshi Task);

        public Solver(string _Name, BehaviorOfSolver _Behaviour) 
        { 
            behavior = _Behaviour; 
            name = _Name;
        }
        
        public string Name
        {
            get { return Name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("SolverName shouldn't be empty, null, or white space!");
                name = value;
            }
        }

        public BehaviorOfSolver Behavior
        {
            get { return behavior; }
            set 
            {
                if (!Enum.IsDefined(typeof(BehaviorOfSolver), value))
                    throw new ArgumentException("Unknown type for solver!");
                behavior = value; 
            }
        }
    }
}
