using System.Collections.Generic;
using System;

namespace KoshiSolvers
{
    abstract class Solver
    {
        private string name;
        private SolverTypes solverType;
        protected BehaviorOfSolver behavior;
        public abstract List<Point> SolveKoshiTask(TaskKoshi Task);

        public Solver(BehaviorOfSolver _Behaviour) { behavior = _Behaviour; }

        public SolverTypes SolverType
        {
            get { return solverType; }
            set
            {
                if (!Enum.IsDefined(typeof(SolverTypes), value)) {
                    throw new ArgumentException("There is no such solver type!");
                }
                solverType = value;
            }
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
            set { behavior = value; }
        }
    }
}
