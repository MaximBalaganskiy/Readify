using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzlesLibrary;

namespace PuzzlesTest
{
    /// <summary>
    /// Represents the Puzzle2 unit test.
    /// </summary>
    [TestClass]
    public class Puzzle2UnitTest
    {
        /// <summary>
        /// Tests if passing negative lenghts raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeSideGetTriangleTypeTest()
        {
            var type = TriangleServices.GetTriangleType(-1, 1, 2);
        }

        /// <summary>
        /// Tests if the GetTriangleType function is able to identify an invalid triangle.
        /// </summary>
        [TestMethod]
        public void InvalidTriangleGetTriangleTypeTest()
        {
            Assert.AreEqual(TriangleServices.TriangleType.Error, TriangleServices.GetTriangleType(1, 2, 4));
        }

        /// <summary>
        /// Tests if the GetTriangleType function is able to identify a scalene triangle.
        /// </summary>
        [TestMethod]
        public void ScaleneGetTriangleTypeTest()
        {
            Assert.AreEqual(TriangleServices.TriangleType.Scalene, TriangleServices.GetTriangleType(3, 4, 5));
        }

        /// <summary>
        /// Tests if the GetTriangleType function is able to identify an equilateral triangle.
        /// </summary>
        [TestMethod]
        public void EquilateralGetTriangleTypeTest()
        {
            Assert.AreEqual(TriangleServices.TriangleType.Equilateral, TriangleServices.GetTriangleType(3, 3, 3));
        }

        /// <summary>
        /// Tests if the GetTriangleType function is able to identify an isosceles triangle.
        /// </summary>
        [TestMethod]
        public void IsoscelesGetTriangleTypeTest()
        {
            Assert.AreEqual(TriangleServices.TriangleType.Isosceles, TriangleServices.GetTriangleType(3, 3, 4));
        }

    }
}
