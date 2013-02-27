using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle1;

namespace PuzzlesUnitTest
{
    /// <summary>
    /// Represents the Puzzle1 unit test.
    /// </summary>
    [TestClass]
    public class Puzzle1UnitTest
    {
        /// <summary>
        /// Tests the length of the list after element have been added.
        /// Tests handling of boundary indexes with different offsets.
        /// </summary>
        [TestMethod]
        public void ElementAtTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.Add(11);
            Assert.AreEqual(10, list.Length, "The length of the list is incorrect.");
            Assert.AreEqual(7, list.ElementAt(4, SingleLinkedList<int>.Offset.Last));
            Assert.AreEqual(2, list.ElementAt(0, SingleLinkedList<int>.Offset.First));
            Assert.AreEqual(11, list.ElementAt(0, SingleLinkedList<int>.Offset.Last));
            Assert.AreEqual(11, list.ElementAt(9, SingleLinkedList<int>.Offset.First));
            Assert.AreEqual(2, list.ElementAt(9, SingleLinkedList<int>.Offset.Last));
        }

        /// <summary>
        /// Tests if calling the function on an empty list raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListElementAtTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.ElementAt(0, SingleLinkedList<int>.Offset.First);
        }

        /// <summary>
        /// Tests if calling the function with an out of bounds index raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OutOfBoundsElementAtTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(2);
            list.Add(3);
            list.ElementAt(2, SingleLinkedList<int>.Offset.First);
        }

        /// <summary>
        /// Tests if calling the function with a negative index raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeIndexElementAtTest()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(2);
            list.Add(3);
            list.ElementAt(-1, SingleLinkedList<int>.Offset.First);
        }

    }
}
