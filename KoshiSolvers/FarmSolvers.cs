using System;
using System.Collections.Generic;

namespace KoshiSolvers
{
    public class FarmSolvers
    {
        // Properties
        public List<Solver> Solvers { get; set; }
        
        // Constructors
        public FarmSolvers() {
           Solvers = new List<Solver>(); 
        }
       
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

        public void SolveTask(TaskKoshi Task)
        {
            foreach (Solver solver in Solvers)
                solver.SolveKoshiTask(Task);
        }

        public void DeleteSolver(string Name)
        { 
            Solvers.Remove(Solvers[this.FindSolverByName(Name)]);
            return;
        }

        public void CheckNameRepeat(string Name)
        {
            try 
            {
                // If not found exception will be rised
                this.FindSolverByName(Name);
                throw new ApplicationException("There is already such solver");
            }

            catch(ArgumentException) {
                return; 
            }
        }
    }
}
