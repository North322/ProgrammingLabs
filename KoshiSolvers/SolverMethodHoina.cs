using System.Collections.Generic;
namespace KoshiSolvers
{
    public class HoinSolver : Solver
    {
        // Constructors
        public HoinSolver(string _Name, BehaviorOfSolver _Behaviour) : base(_Name, _Behaviour) { }

        // Methods
        public override List<Point> Solve(InitialValueProblem Task)
        {
            double StepSize = Task.H;
            double YIntermediate, FunctionIntermediateValue, FunctionValue;
            int i = 1;
            List<Point> Solution = new List<Point>();

            Solution.Add(new Point(Task.T0, Task.Y0));
            FunctionValue = Task.CountFunctionValue(Solution[0].X, Solution[0].Y);

            while (Solution[i - 1].X < Task.T)
            {
                double temp = Solution[i - 1].X + StepSize;

                YIntermediate = Solution[i - 1].Y + StepSize * FunctionValue;
                FunctionIntermediateValue = Task.CountFunctionValue(temp - StepSize, YIntermediate);
                Solution.Add(new Point(temp, Solution[i - 1].Y + StepSize / 2 * (FunctionValue + FunctionIntermediateValue)));

                FunctionValue = Task.CountFunctionValue(Solution[i].X, Solution[i].Y);

                if ((Solution[i].X + StepSize) > Task.T)
                {
                    // Out of border situations
                    switch (Behavior) 
                    {
                        case BehaviorOfSolver.FinishAtTheLeftBorder:
                            StepSize = Task.T - (StepSize * i + Solution[0].X);
                            temp = Solution[i].X + StepSize;

                            YIntermediate = Solution[i].Y + StepSize * FunctionValue;
                            FunctionIntermediateValue = Task.CountFunctionValue(Solution[i + 1].X, YIntermediate);
                            Solution.Add(new Point(temp, Solution[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediateValue)));
                            break;

                        case BehaviorOfSolver.FinishAfterLeftBorder:
                            temp = Solution[i].X + StepSize;
                            
                            YIntermediate = Solution[i].Y + StepSize * FunctionValue;
                            FunctionIntermediateValue = Task.CountFunctionValue(Solution[i + 1].X, YIntermediate);
                            Solution.Add(new Point(temp, Solution[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediateValue)));
                            break;
                        case BehaviorOfSolver.FinishBeforeLeftBorder:
                            break;
                    }
                    break;
                }
                i++;
            }
            return Solution;
        }
    }
}
