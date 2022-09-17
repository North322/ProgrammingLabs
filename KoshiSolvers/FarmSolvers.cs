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
        public void AddSolver(Solver solver)
        {
            solvers.Add(solver);
        }

        public List<Point> SolveProblem(int SolverIndex, TaskKoshi Task)
        {
            return solvers[SolverIndex].SolveKoshiTask(Task);
        }

        public void DeleteSolver(string Name)
        {
            foreach (Solver solver in Solvers)
            {
                if (solver.Name == Name)
                {
                    Solvers.Remove(solver);
                    return;
                }
            }

            throw new ArgumentException("There is no such solver");
        }

        public void CheckNameRepeat(string Name)
        {
            foreach (Solver solver in Solvers)
            {
                if (solver.Name == Name)
                {
                    throw new ArgumentException("Solver with this name already exists");
                }
            }
        }

        public bool isArraySolversEmpty()
        {
           if (Solvers.Count == 0) return true;
           return false;
        }

    }
}
