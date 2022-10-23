using System;
using System.Collections.Generic;

namespace KoshiSolvers
{
    public class Farm
    {
        // Properties
        public List<Solver> Solvers { get; }

        // Constructors
        public Farm()
        {
            Solvers = new List<Solver>();
        }

        // Methods
        public void AddSolver(Solver solver)
        {
            if (solver == null)
                throw new NullReferenceException("Solver can't be null!");
            try
            {
                this.FindSolverByName(solver.Name);
            }
            catch (ArgumentException)
            {
                Solvers.Add(solver);
            }
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

        public List<List<Point>> SolveTask(InitialValueProblem Task)
        {
            List<List<Point>> Solutions = new List<List<Point>>();
            if (Solvers.Count == 0) throw new ApplicationException("There is no solvers yet!");

            foreach (Solver solver in Solvers)
                Solutions.Add(solver.Solve(Task));

            return Solutions;
        }

        public void DeleteSolver(string Name)
        {
            Solvers.Remove(Solvers[this.FindSolverByName(Name)]);
        }

    }
}
