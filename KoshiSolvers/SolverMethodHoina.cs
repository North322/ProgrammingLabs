using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers
{
    class HoinSolver : Solver
    {
        public HoinSolver(BehaviorOfSolver _Behaviour) : base(_Behaviour) { }
        
        public override List<Point> SolveKoshiTask(TaskKoshi Task)
        {
            List<Point> Points = new List<Point>();

            double StepSize = Task.H;
            double YIntermedied, FunctionIntermediedValue, FunctionValue;
            int i = 1;
            Points.Add(new Point(Task.T0, Task.Y0));
            FunctionValue = Task.CountFunctionValue(Points[0].X, Points[0].Y);

            while (Points[i - 1].X <= Task.T)
            {
                YIntermedied = Points[i - 1].Y + StepSize * FunctionValue;
                FunctionIntermediedValue = Task.CountFunctionValue(Points[i].X, YIntermedied);
                Points.Add(new Point(Points[i - 1].X + StepSize, Points[i - 1].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));

                FunctionValue = Task.CountFunctionValue(Points[i].X, Points[i].Y);


                // Особый случай не поподания на конец интервала
                if ((Points[i].X + StepSize) > Task.T)
                {
                    switch (Behavior)//// // случаи непопадания на границу отрезка
                    {
                        case BehaviorOfSolver.NoneBehavior:
                            break;

                        case BehaviorOfSolver.FinishAtTheLeftBorder:

                            StepSize = Task.T - (StepSize * i + Points[0].X);

                            YIntermedied = Points[i].Y + StepSize * FunctionValue;
                            FunctionIntermediedValue = Task.CountFunctionValue(Points[i + 1].X, YIntermedied);
                            Points.Add(new Point(Points[i].X + StepSize, Points[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));
                            break;
                        case BehaviorOfSolver.FinishAfterLeftBorder:
                            YIntermedied = Points[i].Y + StepSize * FunctionValue;
                            FunctionIntermediedValue = Task.CountFunctionValue(Points[i + 1].X, YIntermedied);
                            Points.Add(new Point(Points[i].X + StepSize, Points[i].Y + StepSize / 2 * (FunctionValue + FunctionIntermediedValue)));
                            break;
                        case BehaviorOfSolver.FinishBeforeLeftBorder:
                            break;
                    }
                    break;
                }
                i++;
            }
            return Points;
        }
    }
}
