using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoshiSolvers.Tests
{
    [TestClass()]
    public class EulerSolverTests
    {
        [TestMethod()]
        public void EulerSolverTest()
        {
            var Name = "Test name";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            EulerSolver solver = new EulerSolver(Name, Behavior);

            Assert.IsNotNull(solver);
        }

        [TestMethod()]
        public void SolveKoshiTaskTest()
        {
            Assert.Fail();
        }
    }
}