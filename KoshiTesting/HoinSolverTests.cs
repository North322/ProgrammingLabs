using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers.Tests
{
    [TestClass()]
    public class HoinSolverTests
    {
        [TestMethod()]
        public void HoinSolverTest()
        {
            var Name = "Test name";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)(1);
            HoinSolver solver = new HoinSolver(Name, Behavior);

            Assert.IsNotNull(solver);
        }

        [TestMethod()]
        public void SolveKoshiTaskTest()
        {
            Assert.Fail();
        }
    }
}