using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoshiSolvers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KoshiSolvers.Tests
{
    [TestClass()]
    public class TaskKoshiTests
    {
        [TestMethod()]
        public void TaskKoshiTest()
        {
            double y0 = 1.2; double t0 = 0.1; double t = 1; double h = 2;
            TaskKoshi test = new TaskKoshi(y0, t0, t, h);

            Assert.IsNotNull(test);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "Right border must be greater than left one")]
        public void TaskKoshiInitBorder_ThrowExceptionTest()
        {
            double t0 = 1;
            double t = t0;

            TaskKoshi test = new TaskKoshi(1, t0, t, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "Step can't have zero or negative value")]
        public void TaskKoshiInitStep_ThrowExceptionTest()
        {
            double step = -1.2;
            TaskKoshi test = new TaskKoshi(1, 1, 2, step);
        }

        [TestMethod()]
        public void CountFunctionValueTest()
        {
            TaskKoshi test = new TaskKoshi(1, 1, 2, 1);
            double expected = test.CountFunctionValue(12.3, -4.5);
            double actual = 0.1357155724343044;

            Assert.AreEqual(expected, actual, 0.0000000000000001, "The accuracy of the module is insufficient or the solution is incorrect");
        }
    }
}