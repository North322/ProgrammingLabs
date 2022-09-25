using System.Collections.Generic;
using System;

namespace KoshiSolvers
{
    abstract class Solver
    {
        private BehaviorOfSolver behaviour;
        private string name;
        private List<Point> solution;

        public abstract void SolveKoshiTask(TaskKoshi Task);

        public Solver(string _Name, BehaviorOfSolver _Behaviour)
        {
            Behavior = _Behaviour;
            Name = _Name;
            Solution = new List<Point>();
        }

        public List<Point> Solution
        {
            get { return solution; }
            set { solution = value; }
        }

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

        public BehaviorOfSolver Behavior
        {
            get { return behaviour; }
            set
            {
                if (!Enum.IsDefined(typeof(BehaviorOfSolver), value))
                    throw new ArgumentException("Unknown type for solver!");
                behaviour = value;
            }
        }
    }
}
