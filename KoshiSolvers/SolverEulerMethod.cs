using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers
{
    class EulerSolver: Solver
    {
        public EulerSolver(BehaviorOfSolver _Behaviour) : base(_Behaviour) { }
        
        public override List<Point> SolveKoshiTask(TaskKoshi Task)
        {
            List<Point> Points = new List<Point>();
            double FunctionValue;
            double StepSize = Task.H;

            int i = 1;

            Points.Add(new Point(Task.T0, Task.Y0));
            FunctionValue = Task.CountFunctionValue(Points[0].X, Points[0].Y);

            while (Points[i - 1].X <= Task.T)
            {
                Points.Add(new Point(Points[i - 1].X + StepSize, Points[i - 1].Y + StepSize * FunctionValue));
                FunctionValue = Task.CountFunctionValue(Points[i].X, Points[i].Y);

                // случаи непопадания на границу отрезка
                if ((Points[i].X + StepSize) > Task.T)
                {
                    switch (Behavior)
                    {
                        case BehaviorOfSolver.NoneBehavior:
                            break;

                        case BehaviorOfSolver.FinishAtTheLeftBorder:

                            StepSize = Task.T - (StepSize * i + Points[0].X);

                            Points.Add(new Point(Points[i].X + StepSize, Points[i].Y + StepSize * FunctionValue));
                            break;

                        case BehaviorOfSolver.FinishAfterLeftBorder:
                            Points.Add(new Point(Points[i].X + StepSize, Points[i].Y + StepSize * FunctionValue));
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

