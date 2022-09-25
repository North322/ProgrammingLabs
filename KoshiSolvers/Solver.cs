using System.Collections.Generic;
using System;

namespace KoshiSolvers
{
    abstract class Solver
    {
        public abstract void SolveKoshiTask(TaskKoshi Task);

        public Solver(string _Name, BehaviorOfSolver _Behaviour) 
        { 
            Behavior = _Behaviour; 
            Name = _Name;
        }
        
        public List<Point> Solution { get; set; }
        
        public string Name
        {
            get { return Name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("SolverName shouldn't be empty, null, or white space!");
                Name = value;
            }
        }

        public BehaviorOfSolver Behavior
        {
            get { return Behavior; }
            set 
            {
                if (!Enum.IsDefined(typeof(BehaviorOfSolver), value))
                    throw new ArgumentException("Unknown type for solver!");
                Behavior = value; 
            }
        }
    }
}
