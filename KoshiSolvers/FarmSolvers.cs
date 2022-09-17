using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers
{
    class FarmSolvers
    {
        // Data
        private List<Solver> solvers;

        // Constructors
        public FarmSolvers() {}
        
        public List<Solver> Solvers
        {
            get { return solvers; }
        }

        // Methods
        public void AddSolver(SolverTypes solverType, BehaviorOfSolver behavior)
        {
            switch (solverType) {
                case SolverTypes.EulerSolver:
                    solvers.Add(new EulerSolver(behavior));
                    break;
                case SolverTypes.HoinSolver:
                    solvers.Add(new HoinSolver(behavior));
                    break;
            }
        }

        public List<Point> SolveProblem(int SolverIndex, TaskKoshi Task)
        {
            return solvers[SolverIndex].SolveKoshiTask(Task);
        }

        public bool DeleteSolver(string Name)
        {
            foreach (Solver solver in Solvers)
            {
                if (solver.Name == Name)
                {
                    Solvers.Remove(solver);
                    return true;
                }
            }
            return false;
        }

        public void CheckNameRepeat(string Name)
        {
            foreach (Solver solver in Solvers)
            {
                if (solver.Name == Name)
                {
                    throw new ArgumentException("This name already exists");
                }
            }
        } 
        
        public bool IsArraySolversEmpty()
        {
           if (Solvers.Count == 0) return true;
           return false;
        }

    }
}
