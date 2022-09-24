using System;
namespace KoshiSolvers
{
    class Menu
    {
        public void listen()
        {
            while (true)
            {
                Console.Write($"\n\tMenu options\n" + 
                        $"{ADD_SOLVER_OPTION}-Add hourly wage worker\n" +
                        $"{DELETE_SOLVER_OPTION}-Add commission wage worker\n" +
                        $"{PRINT_SOLVERS_OPTION}-Fire worker by full name\n" +
                        $"{SOLVE_TASK_OPTION}-Simulate work\n" +
                        $"{PRINT_SOLUTIONS_OPTION}-Print hourly wage workers\n" +
                        $"{EXIT_OPTION}-EXIT\n\n");

                Console.Write("Enter option: ");
                byte option = Convert.ToByte(Console.ReadLine());

                switch (option) {
                    case 1:
                        handleAddSolverOption(); 
                        break;
                    case 2:
                        handleDeleteSolverOption();
                        break;
                    case 3:
                        handlePrintSolversOption();
                        break;
                    case 4:
                        handleSolveTaskOption();
                        break;
                    case 5:
                        handlePrintSolutions();
                        break;
                    case 6:
                        return;
                    default:
                        Console.Write("There is no such option!");
                        break;
                }
            }
        }

        private FarmSolvers farm;

        const short ADD_SOLVER_OPTION = 1;
        const short DELETE_SOLVER_OPTION = 2;
        const short PRINT_SOLVERS_OPTION = 3;
        const short SOLVE_TASK_OPTION = 4;
        const short PRINT_SOLUTIONS_OPTION = 5;
        const short EXIT_OPTION = 6;

        private void handleAddSolverOption()
        {
            try
            {
                Console.Write("Enter solver type: ");
                SolverTypes Type = (SolverTypes)Convert.ToByte(Console.ReadLine());
                Console.Write("Enter solver name: ");
                string Name = Console.ReadLine();
                farm.CheckNameRepeat(Name);
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
                        throw new ArgumentException("Wrong solver type!");
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
                Console.Write("Enter solver name: ");
                string Name = Console.ReadLine();
                farm.DeleteSolver(Name);
                Console.WriteLine("Solver was successfully deleted");
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
            foreach (Solver solver in farm.Solvers)
            {
                Console.WriteLine(solver.ToString());
            }
        }

        private void handleSolveTaskOption()
        {
            Console.Write("Enter solver name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter y0: ");
            double y0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter t0: ");
            double t0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter t: ");
            double t = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter h: ");
            double h = Convert.ToDouble(Console.ReadLine());
            farm.Solvers[farm.FindSolverByName(Name)].SolveKoshiTask(new TaskKoshi(y0, t0, t, h));
        }

        private void handlePrintSolutions()
        {
            int i;

            foreach (Solver solver in farm.Solvers)
            {
                i = 0;
                foreach (Point point in solver.Solution)
                {
                    Console.WriteLine($"x{i}: {point.X}, y{i}: {point.Y}");
                    i++;
                }
            }
        }
    }
}
