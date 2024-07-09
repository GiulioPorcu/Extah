using System.Collections;

namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="ICollection"/> objects.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Concatenates this and another collection.
        /// <br></br><br></br>
        /// <see cref="ArgumentNullException"/> - if the sorting order is not a valid value.
        /// </summary>
        /// <param name="collection">The original collection</param>
        /// <param name="values">Another collection of values to be added to this</param>
        public static void Add<T>(this ICollection<T> collection, ICollection<T> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (T element in values)
            {
                collection.Add(element);
            }
        }

        /// <summary>
        /// Traverses the collection and checks if the value is within.
        /// </summary>
        /// <param name="enumerable">The original collection.</param>
        /// <param name="value">The element to look out for</param>
        /// <returns><see langword="true"/> if the element was found</returns>
        public static bool Contains<T>(this ICollection<T> enumerable, T value)
        {
            foreach (T element in enumerable)
            {
                if (element.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Performs the specified action for each member in this object.
        /// </summary>
        /// <param name="enumerable">The original collection</param>
        /// <param name="action">The action to perform on each element</param>
        public static void ForEach<T>(this ICollection<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
            {
                action(element);
            }
        }

        /// <summary>
        /// Checks if this collection contains zero elements.
        /// </summary>
        /// <param name="collection">The original collection</param>
        /// <returns><see langword="true"/> if the collection count equals zero</returns>
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count == 0;
        }

        /// <summary>
        /// Checks if this collection contains any elements.
        /// </summary>
        /// <param name="collection">The original collection</param>
        /// <returns><see langword="true"/> if the collection count is greater than zero</returns>
        public static bool IsNotEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count > 0;
        }

        /// <summary>
        /// Removes values from this set.
        /// </summary>
        /// <param name="collection">The original set.</param>
        /// <param name="values">A collection of objects.</param>
        public static void Remove<T>(this ICollection<T> collection, ICollection<T> values)
        {
            foreach (T element in values)
            {
                collection.Remove(element);
            }
        }

        /// <summary>
        /// Sorts this collection.
        /// </summary>
        /// <param name="collection">The original collection</param>
        public static void Sort<T>(this ICollection<T> collection) where T : IComparable
        {
            ArrayList.Adapter((IList)collection).Sort();
        }

        /// <summary>
        /// Creates a new array that contains this collection's elements.
        /// </summary>
        /// <param name="enumerable">The original collection</param>
        /// <returns>An array with values from this collection</returns>
        public static T[] ToArray<T>(this ICollection<T> enumerable)
        {
            return Enumerable.ToArray(enumerable);
        }
    }
}