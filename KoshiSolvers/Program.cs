using System;

enum BehaviorOfSolver : byte { FinishAtTheLeftBorder = 1, FinishAfterLeftBorder, FinishBeforeLeftBorder };
enum SolverTypes : byte {EulerSolver = 1, HoinSolver};

namespace KoshiSolvers
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.listen();
        }
    }
}
