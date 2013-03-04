using System;

namespace PuzzlesLibrary
{
    /// <summary>
    /// Represents the static class holding triangle service functions.
    /// </summary>
    public static class TriangleServices
    {

        #region Subtypes

        /// <summary>
        /// Defines possible triangle types.
        /// </summary>
        public enum TriangleType
        {
            /// <summary>
            /// Three equal sides.
            /// </summary>
            Equilateral = 3,
            /// <summary>
            /// Two equal sides.
            /// </summary>
            Isosceles = 1,
            /// <summary>
            /// No equal sides.
            /// </summary>
            Scalene = 0,
            /// <summary>
            /// Invalid triangle.
            /// </summary>
            Error = 4
        };

        #endregion

        #region Methods

        /// <summary>
        /// Returns the type of the triangle with specified side lengths.
        /// </summary>
        /// <param name="a">The length of the side A.</param>
        /// <param name="b">The length of the side B.</param>
        /// <param name="c">The length of the side C.</param>
        /// <returns>The type of the triangle.</returns>
        public static TriangleType GetTriangleType(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Invalid side length.");
            }

            // the sum of any 2 side lenghts of a valid triangle should be greater than the length of the remaining side
            if (a + b < c || a + c < b || b + c < a)
            {
                return TriangleType.Error;
            }

            // the number of equalities identifies the type of the triangle
            int equalities = (a == b ? 1 : 0) + (a == c ? 1 : 0) + (b == c ? 1 : 0);
            return (TriangleType)equalities;
        }

        #endregion

    }
}
