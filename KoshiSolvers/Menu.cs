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

        private void handleAddSolverOption()
        {
            try
            {
                Console.Write("Enter solver type: ");
                SolverTypes Type = (SolverTypes)Convert.ToByte(Console.ReadLine());
                Console.Write("Enter solver name: ");
                string Name = Console.ReadLine();
                Console.Write("Enter solver behavior(1 - Stop at left border, 2 - after left border, 3 - before left border): ");
                BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(Console.ReadLine());

                switch (Type)
                {
                    case SolverTypes.EulerSolver:
                        farm.Solvers.Add(new EulerSolver(Name, Behavior));
                        break;
                    case SolverTypes.HoinSolver:
                        farm.Solvers.Add(new HoinSolver(Name, Behavior));
                        break;
                    default:
                        throw new ArgumentException("Неверный тип решателя");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void handleDeleteSolverOption()
        {
            try
            {
                Console.Write("Введите название решателя: ");
                string Name = Console.ReadLine();
                farm.DeleteSolver(Name);
                Console.WriteLine("");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        // Think about data output. Method shoudn't print smth in Console
        // Probably should use streams instead of Console.WriteLine
        private void handlePrintSolversOption()
        {
           foreach (Solver solver in farm.Solvers) {
               Console.WriteLine(solver.ToString());
           }              
        }

        private void handleSolveTaskOption()
        {
            Console.WriteLine("Enter solver name: ");
            string Name = Console.ReadLine(); 
              
            farm.Solvers[farm.FindSolverByName(Name)].SolveKoshiTask(Task);
        }
    }
}
