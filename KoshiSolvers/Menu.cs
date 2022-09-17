using System;
enum Tasks { }
namespace KoshiSolvers
{
    class Menu
    {
        public void listen() { }

        private FarmSolvers farm;

        const short ADD_SOLVER_OPTION = 1;
        const short DELETE_SOLVER_OPTION = 2;
        const short PRINT_SOLVERS_OPTION = 3;
        const short SOLVE_TASK_OPTION = 4;

        private void handleAddSolverOption(SolverTypes solverType, BehaviorOfSolver behavior)
        {
            try
            {
                farm.AddSolver(solverType, behavior);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void handleDeleteSolverOption(string name)
        {
            farm.DeleteSolver(name);
        }
        
        // Think about data output. Method shoudn't print smth in Console
        // Probably should use streams instead of Console.WriteLine
        private void handlePrintSolversOption() 
        {

        }

        private void handleSolveTaskOption(int solverIndex, TaskKoshi Task) {
            farm.Solvers[solverIndex].SolveKoshiTask(Task);
        }
    }
}
