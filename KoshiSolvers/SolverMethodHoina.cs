namespace KoshiSolvers
{
    public class HoinSolver : Solver
    {
        // Constructors
        public HoinSolver(string _Name, BehaviorOfSolver _Behaviour) : base(_Name, _Behaviour) { }

        // Methods
        public override void SolveKoshiTask(TaskKoshi Task)
        {
            double StepSize = Task.H;
            double YIntermedied, FunctionIntermediedValue, FunctionValue;
            int i = 1;

            Solution.Clear();   
            Solution.Add(new Point(Task.T0, Task.Y0));
            FunctionValue = Task.CountFunctionValue(Solution[0].X, Solution[0].Y);

            while (Solution[i - 1].X < Task.T)
            {
                double temp = Solution[i - 1].X + StepSize;
                YIntermedied = Solution[i - 1].Y + StepSize * FunctionValue;
                FunctionIntermediedValue = Task.CountFunctionValue(temp, YIntermedied);
                Solution.Add(new Point(temp, Solution[i - 1].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));

                FunctionValue = Task.CountFunctionValue(Solution[i].X, Solution[i].Y);

                // Особый случай не поподания на конец интервала
                if ((Solution[i].X + StepSize) > Task.T)
                {
                    switch (Behavior)//// // случаи непопадания на границу отрезка
                    {
                        case BehaviorOfSolver.FinishAtTheLeftBorder:

                            StepSize = Task.T - (StepSize * i + Solution[0].X);
                            temp = Solution[i].X + StepSize;
                            YIntermedied = Solution[i].Y + StepSize * FunctionValue;
                            FunctionIntermediedValue = Task.CountFunctionValue(temp, YIntermedied);
                            Solution.Add(new Point(temp, Solution[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));
                            break;
                        case BehaviorOfSolver.FinishAfterLeftBorder:
                            temp = Solution[i].X + StepSize;
                            YIntermedied = Solution[i].Y + StepSize * FunctionValue;
                            FunctionIntermediedValue = Task.CountFunctionValue(temp, YIntermedied);
                            Solution.Add(new Point(temp, Solution[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));
                            break;
                        case BehaviorOfSolver.FinishBeforeLeftBorder:
                            break;
                    }
                }
                i++;
            }
        }
    }
}
