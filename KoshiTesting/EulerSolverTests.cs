using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml.Linq;

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

        private FarmSolvers _anInstance = new FarmSolvers();

        public void GenerateTestName(string Name = "Test name", byte behavior = 1)
        {
            BehaviorOfSolver Behavior = (BehaviorOfSolver)(behavior);
            EulerSolver testSolver = new EulerSolver(Name, Behavior);

            _anInstance.Solvers.Add(testSolver);
        }

        [TestMethod()]
        [Timeout(200)]  // Milliseconds
        public void SolveKoshiTaskTest()
        {
            var name = "Testname";
            GenerateTestName(name);
            TaskKoshi task = new TaskKoshi(1.0, 0.0, 1.0, 1.0);
            _anInstance.SolveTask(task);
            int i = 0, index = _anInstance.FindSolverByName(name);
            double expected = 1.0174524064372834;

            foreach (Point point in _anInstance.Solvers[index].Solution)
            {
                if (point.X == 1) Assert.AreEqual(expected, point.Y, 0.00001, "Euler Method Calculating Error");

                Console.WriteLine($"x{i}: {point.X}, y{i}: {point.Y}");
                i++;
            }
        }
    }
}