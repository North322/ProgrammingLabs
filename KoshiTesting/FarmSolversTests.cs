using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KoshiSolvers.Tests
{
    class TestSolver : Solver
    {
        public TestSolver(string _Name, BehaviorOfSolver _Behaviour) : base(_Name, _Behaviour) { }

        public override void SolveKoshiTask(TaskKoshi Task)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass()]
    public class FarmSolversTests
    {
        [TestMethod()]
        public void AddSolverTest()
        {
            var anInstance = new FarmSolvers();
            var Name = "Testing";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            Solver solver = new TestSolver(Name, Behavior);

            anInstance.Solvers.Add(solver);

            Assert.AreEqual(Name, Name, "Solver changes name");
            Assert.AreEqual(Behavior, Behavior, "Solver changes name");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "SolverName shouldn't be empty, null, or white space!")]
        public void ThrowExceptionTest()
        {
            var anInstance = new FarmSolvers();
            var Name = "";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            Solver solver = new TestSolver(Name, Behavior);

            anInstance.Solvers.Add(solver);
        }

        [TestMethod()]
        public void FindSolverByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SolveProblemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteSolverTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckNameRepeatTest()
        {
            Assert.Fail();
        }
    }
}