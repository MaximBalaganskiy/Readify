using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzlesLibrary;

namespace PuzzlesTest
{
    [TestClass]
    public class Puzzle3UnitTest
    {
        [TestMethod]
        public void SplitTest()
        {
            string str = "  one reeeeeeeeeeeealy long word is not enough, so  i will add more than 10 words to see the result   ";
            string[] res = str.PuzzleSplit(' ');
            string[] expected = str.Split(' ');
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringSplitTest()
        {
            string str = null;
            string[] res = str.PuzzleSplit(' ');
        }

        [TestMethod]
        public void EmptyStringSplitTest()
        {
            string str = string.Empty;
            string[] res = str.PuzzleSplit(' ');
            string[] expected = str.Split(' ');
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ReverseTest()
        {
            Assert.AreEqual("eno", "one".PuzzleReverse());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringReverseTest()
        {
            string str = null;
            str.PuzzleReverse();
        }

        [TestMethod]
        public void EmptyStringReverseTest()
        {
            Assert.AreEqual(string.Empty, string.Empty.PuzzleReverse());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringReverseWordsTest()
        {
            string str = null;
            str.ReverseWords(' ');
        }

        [TestMethod]
        public void ReverseWordsTest()
        {
            Assert.AreEqual("  tac dna    god  ", "  cat and    dog  ".ReverseWords(' '));
        }

        [TestMethod]
        public void EmptyStringReverseWordsTest()
        {
            Assert.AreEqual(string.Empty, string.Empty.ReverseWords(' '));
        }

    }
}
