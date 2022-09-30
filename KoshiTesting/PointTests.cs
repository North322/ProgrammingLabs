using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using KoshiSolvers;

namespace KoshiSolvers.Tests
{
    [TestClass()]
    public class PointTests
    {
        [TestMethod()]
        [Timeout(20)]  // Milliseconds
        public void MainTest()
        {
            // Arrange
            double expectedX = 11.23;
            double expectedY = -3.003;
            Point test = new Point(expectedX, expectedY);

            // Act
            double actualX = test.X;
            double actualY = test.Y;

            // Assert
            Assert.AreEqual(expectedX, actualX, 0.001, "unexpected X in Point");
            Assert.AreEqual(expectedY, actualY, 0.001, "unexpected Y in Point");
        }

        [TestMethod()]
        public void IntEqualsDoubleTest()
        {
            // Arrange
            int expectedX = 11;
            int expectedY = -3;
            Point test = new Point(expectedX, expectedY);

            // Act
            double actualX = test.X;
            double actualY = test.Y;

            // Assert
            Assert.AreEqual(expectedX, actualX, 0.001, "Int not equals Double in X in Point");
            Assert.AreEqual(expectedY, actualY, 0.001, "Int not equals Double in Y in Point");
        }
    }
}