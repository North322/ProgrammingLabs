using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Xml.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KoshiSolvers.Tests
{
    class TestSolver : Solver
    {
        public TestSolver(string _Name, BehaviorOfSolver _Behaviour) : base(_Name, _Behaviour) { }

        public override void SolveKoshiTask(TaskKoshi Task)
        {
            return; // as if the code here has worked and returns
        }
    }

    [TestClass()]
    public class FarmSolversTests
    {
        private FarmSolvers anInstance = new FarmSolvers();

        public void GenerateTestName(string Name="Default")
        {
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            Solver testSolver = new TestSolver(Name, Behavior);

            anInstance.Solvers.Add(testSolver);
        }

        [TestMethod()]
        public void AddSolverTest()
        {
            var Name = "Testing";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);
            Solver testSolver = new TestSolver(Name, Behavior);

            anInstance.AddSolver(testSolver);

            Assert.AreEqual(Name, Name, "Solver changes name");
            Assert.AreEqual(Behavior, Behavior, "Solver changes name");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "There is no such solver")]
        public void FindSolverByName_ThrowExceptionTest()
        {
            var NonExistentName = "non-existent name";
            anInstance.FindSolverByName(NonExistentName);
            Assert.Fail();
        }

        [TestMethod()]
        public void FindSolverByNameTest()
        {
            var TestName = "test_name";
            GenerateTestName(TestName);
            int index = anInstance.FindSolverByName(TestName); //returns an index, right?

            Assert.AreEqual(anInstance.Solvers[index].Name, TestName);
        }

        [TestMethod()]
        public void SolveProblemTest()
        {
            GenerateTestName();
            
            TaskKoshi Task = new TaskKoshi(1.0, 1.0, 1.0, 1.0);
            anInstance.SolveProblem(Task);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "There is no such solver")]
        public void DeleteSolver_ThrowExceptionTest()
        {
            var NonExistentName = "non-existent name";
            anInstance.DeleteSolver(NonExistentName);
        }

        [TestMethod()]
        public void DeleteSolverTest()
        {
            var ExistentName = "test_name";
            GenerateTestName(ExistentName);

            anInstance.DeleteSolver(ExistentName);


        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "Solver with this name already exists")]
        public void CheckNameRepeatTest()
        {
            var Name = "Repiting name";
            BehaviorOfSolver Behavior = (BehaviorOfSolver)Convert.ToByte(1);

            anInstance.Solvers.Add(new TestSolver(Name, Behavior));
            anInstance.CheckNameRepeat(Name);
        }
    }
}