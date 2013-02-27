using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle1
{
    /// <summary>
    /// Represents a strong typed single linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SingleLinkedList<T>
    {

        #region Subtypes

        /// <summary>
        /// Defines possible offsets for the function <seealso cref="ElementAt"/>.
        /// </summary>
        public enum Offset { First, Last }

        /// <summary>
        /// Represents a node of a single linked list.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// The link to the next node in the list.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// The value stored by the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Creates an instance of the <seealso cref="Node"/> type.
            /// </summary>
            /// <param name="value">The value stored by the node.</param>
            /// <param name="next">The link to the next node in the list.</param>
            public Node(T value, Node next)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Stores the reference to the first node in the list.
        /// </summary>
        private Node _first;

        /// <summary>
        /// Stores the reference to the last node in the list.
        /// </summary>
        private Node _last;

        /// <summary>
        /// Stores the number of nodes in the list.
        /// </summary>
        private int _length;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of nodes in the list.
        /// </summary>
        public int Length { get { return _length; } }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the element to the end of the list.
        /// </summary>
        /// <param name="value">The element to be added.</param>
        public void Add(T value)
        {
            if (Length == int.MaxValue)
            {
                throw new InvalidOperationException("The maximum length of the list is exceeded.");
            }

            var newElement = new Node(value, null);
            if (_last != null)
            {
                _last.Next = newElement;
                _last = newElement;
                _length++;
            }
            else
            {
                _first = _last = newElement;
                _length = 1;
            }
        }

        /// <summary>
        /// Returns the element at the specified index in the list.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <param name="offset">The offset of the index.</param>
        /// <returns>The element at the specified index.</returns>
        public T ElementAt(int index, Offset offset)
        {
            if (_first == null || index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException("index", "Index is outside the bounds of the list.");
            }

            if (offset == Offset.First)
            {
                // there is no need to go through the list if the last element is requested 
                if (index == Length - 1)
                {
                    return _last.Value;
                }

                Node node = _first;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node.Value;
            }
            else
            {
                return ElementAt(Length - 1 - index, Offset.First);
            }
        }

        #endregion

    }
}
