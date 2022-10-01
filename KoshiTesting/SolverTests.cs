using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers.Tests
{
    class SolverTestMethod : Solver
    {
        public SolverTestMethod(string _Name, BehaviorOfSolver _Behaviour) : base(_Name, _Behaviour) { }

        public override void SolveKoshiTask(TaskKoshi Task)
        {
            return; // as if the code here has worked and returns
        }
    }

    [TestClass()]
    public class SolverTests
    {
        [TestMethod()]
        private SolverTestMethod SolverTest()
        {
            var anInstance = new FarmSolvers();
            var Name = "Test name";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            SolverTestMethod solver = new SolverTestMethod(Name, Behavior);

            anInstance.Solvers.Add(solver);
            return solver;

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "SolverName shouldn't be empty, null, or white space!")]
        public void Name_ThrowExceptionTest()
        {
            var anInstance = new FarmSolvers();
            var Name = "";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            SolverTestMethod solver = new SolverTestMethod(Name, Behavior);

            anInstance.Solvers.Add(solver);
        }

        [TestMethod()]
        public void SolveKoshiTaskTest()
        {
            var solver = SolverTest();

            TaskKoshi Task = new TaskKoshi(1.0, 1.0, 1.0, 1.0);

            solver.SolveKoshiTask(Task);
        }

        
    }
}