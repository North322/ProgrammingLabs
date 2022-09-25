public enum BehaviorOfSolver : byte { FinishAtTheLeftBorder = 1, FinishAfterLeftBorder, FinishBeforeLeftBorder };
public enum SolverTypes : byte {EulerSolver = 1, HoinSolver};

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
