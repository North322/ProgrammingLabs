public enum BehaviorOfSolver : byte { FinishAtTheLeftBorder = 1, FinishAfterLeftBorder, FinishBeforeLeftBorder };
public enum SolverTypes : byte {EulerSolver = 1, HoinSolver};

namespace KoshiSolvers
{
    class Program
    {
        
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Menu menu = new Menu();
            menu.Listen();
        }
    }
}
