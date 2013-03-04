using System;
using System.Text;

namespace PuzzlesLibrary
{
    /// <summary>
    /// Represents the static class providing extension methods to the string class.
    /// </summary>
    public static class StringExtensions
    {

        #region Constants

        /// <summary>
        /// Stores the initial size of the result array. The array gets incremented with this number if the number of words is greater than current array capacity.
        /// </summary>
        private const int wordsInitialSize = 10;

        /// <summary>
        /// Stores the initial size of the word array. The array gets incremented with this number if the number of characters is greater than current array capacity.
        /// </summary>
        private const int wordInitialSize = 10;

        #endregion

        #region Methods

        /// <summary>
        /// Splits the given string using the specified separator.
        /// </summary>
        /// <param name="str">The string to be split.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The array of words contained in the spesified string.</returns>
        public static string[] PuzzleSplit(this string str, char separator)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "The method is called on a null string.");
            }

            if (str.Length == 0)
            {
                return new string[1] { string.Empty };
            }

            // the array of words with initial size of wordsCacheSize which will be increased should the need arise
            string[] result = new string[wordsInitialSize];
            int words = 0;
            // the array of chars building the current word. The initial size will be increased should the need arise
            char[] word = new char[wordInitialSize];
            int wordLength = 0;
            // the loop is deliberately made to reach str.Length to allow for flushing the last word to the array
            for (int i = 0; i <= str.Length; i++)
            {
                // put the character to the word being built if it is not a separator
                if (i < str.Length && str[i] != separator)
                {
                    // increase the size of the word array if current word does not fit
                    if (wordLength == word.Length)
                    {
                        // depending on the typical word length this could be changed to implement more memory expensive (e.g. exponential) resize strategy
                        Array.Resize(ref word, word.Length + wordInitialSize);
                    }

                    word[wordLength++] = str[i];
                }

                // flush the word being built to the result array if separator or the character "after the last" occurs
                if (i == str.Length || str[i] == separator)
                {
                    // increase the size of the result array if there is not enough space for a new word
                    if (words == result.Length)
                    {
                        // depending on the typical number of words this could be changed to implement more memory expensive (e.g. exponential) resize strategy
                        Array.Resize(ref result, result.Length + wordsInitialSize);
                    }

                    result[words++] = new string(word, 0, wordLength);
                    // clear the word being built
                    wordLength = 0;
                }

            }

            // trim the result array to the actual size
            Array.Resize(ref result, words);
            return result;
        }

        /// <summary>
        /// Reverses the characters in the specified string and returns the result as a new string.
        /// </summary>
        /// <param name="str">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string PuzzleReverse(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "The method is called on a null string.");
            }

            if (str.Length == 0)
            {
                return string.Empty;
            }

            char[] result = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[str.Length - 1 - i] = str[i];
            }

            return new string(result);
        }

        /// <summary>
        /// Reverses every word in the specified string.
        /// </summary>
        /// <param name="str">The string to reverse words in.</param>
        /// <param name="separator">The words separator.</param>
        /// <returns>The string with reversed words in it.</returns>
        public static string ReverseWords(this string str, char separator)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "The method is called on a null string.");
            }

            if (str.Length == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            // split the string into words
            string[] words = str.PuzzleSplit(separator);
            for (int i = 0; i < words.Length; i++)
            {
                // reverse each word and append it to the result
                sb.Append(words[i].PuzzleReverse());
                // append a seperator if the word is not the last
                if (i < words.Length - 1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }
        
        #endregion
    }
}
