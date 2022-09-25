using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers
{
    class FarmSolvers
    {
        // Constructors
        public FarmSolvers() { }

        public List<Solver> Solvers { get; set; }
        

        // Methods
        public void AddSolver(Solver solver)
        {
            Solvers.Add(solver);
        }

        public int FindSolverByName(string Name)
        {
            int index = 0;
            foreach (Solver solver in Solvers)
            {
                if (solver.Name == Name)
                {
                    return index;
                }
                index++;
            }
            throw new ArgumentException("There is no such solver");
        }

        public void SolveProblem(TaskKoshi Task)
        {
            foreach (Solver solver in Solvers)
                solver.SolveKoshiTask(Task);
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
    }
}
