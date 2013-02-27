using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzlesLibrary;

namespace PuzzlesTest
{
    /// <summary>
    /// Represents the Puzzle3 unit test.
    /// </summary>
    [TestClass]
    public class Puzzle3UnitTest
    {
        /// <summary>
        /// Tests if the sentence containing more than 10 words with one of them containing more than 10 characters 
        /// produces the same result as a .NET library function.
        /// </summary>
        [TestMethod]
        public void SplitTest()
        {
            string str = "  one reeeeeeeeeeeealy long word is not enough, so  i will add more than 10 words to see the result   ";
            string[] res = str.PuzzleSplit(' ');
            string[] expected = str.Split(' ');
            CollectionAssert.AreEqual(expected, res);
        }

        /// <summary>
        /// Tests if splitting a null string raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringSplitTest()
        {
            string str = null;
            string[] res = str.PuzzleSplit(' ');
        }

        /// <summary>
        /// Tests if splitting an empty string produces the same result as a .NET library function..
        /// </summary>
        [TestMethod]
        public void EmptyStringSplitTest()
        {
            string str = string.Empty;
            string[] res = str.PuzzleSplit(' ');
            string[] expected = str.Split(' ');
            CollectionAssert.AreEqual(expected, res);
        }

        /// <summary>
        /// Tests if reversing a string produces an expected result.
        /// </summary>
        [TestMethod]
        public void ReverseTest()
        {
            Assert.AreEqual("eno", "one".PuzzleReverse());
        }

        /// <summary>
        /// Tests if reversing a null string raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringReverseTest()
        {
            string str = null;
            str.PuzzleReverse();
        }

        /// <summary>
        /// Tests if reversing an empty string produces an empty string.
        /// </summary>
        [TestMethod]
        public void EmptyStringReverseTest()
        {
            Assert.AreEqual(string.Empty, string.Empty.PuzzleReverse());
        }

        /// <summary>
        /// Tests if reversing words in a null string raises an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringReverseWordsTest()
        {
            string str = null;
            str.ReverseWords(' ');
        }

        /// <summary>
        /// Tests if reversing words in a string produces an expected result and keeps spaces.
        /// </summary>
        [TestMethod]
        public void ReverseWordsTest()
        {
            Assert.AreEqual("  tac dna    god  ", "  cat and    dog  ".ReverseWords(' '));
        }

        /// <summary>
        /// Tests if reversing words in an empty string produces an empty string.
        /// </summary>
        [TestMethod]
        public void EmptyStringReverseWordsTest()
        {
            Assert.AreEqual(string.Empty, string.Empty.ReverseWords(' '));
        }

    }
}
