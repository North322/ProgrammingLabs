namespace KoshiSolvers
{
    class EulerSolver: Solver
    {
        // Constructors
        public EulerSolver(string _Name, BehaviorOfSolver _Behaviour) : base(_Name ,_Behaviour) { }
        
        // Methods
        public override void SolveKoshiTask(TaskKoshi Task)
        {
            double FunctionValue;
            double StepSize = Task.H;

            int i = 1;

            Solution.Clear();
            Solution.Add(new Point(Task.T0, Task.Y0));
            FunctionValue = Task.CountFunctionValue(Solution[0].X, Solution[0].Y);

            while (Solution[i - 1].X <= Task.T)
            {
                Solution.Add(new Point(Solution[i - 1].X + StepSize, Solution[i - 1].Y + StepSize * FunctionValue));
                FunctionValue = Task.CountFunctionValue(Solution[i].X, Solution[i].Y);

                // случаи непопадания на границу отрезка
                if ((Solution[i].X + StepSize) > Task.T)
                {
                    switch (Behavior)
                    {
                        case BehaviorOfSolver.FinishAtTheLeftBorder:

                            StepSize = Task.T - (StepSize * i + Solution[0].X);

                            Solution.Add(new Point(Solution[i].X + StepSize, Solution[i].Y + StepSize * FunctionValue));
                            break;

                        case BehaviorOfSolver.FinishAfterLeftBorder:
                            Solution.Add(new Point(Solution[i].X + StepSize, Solution[i].Y + StepSize * FunctionValue));
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

