using System.Collections;

namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="IEnumerable"/> objects.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Traverses the enumerable and checks if the value is within.
        /// </summary>
        /// <param name="enumerable">The original enumerable</param>
        /// <param name="value">The element to look out for</param>
        /// <returns><see langword="true"/> if the element was found</returns>
        public static bool Contains<T>(this IEnumerable<T> enumerable, T value)
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
        /// <param name="enumerable">The original enumerable</param>
        /// <param name="action">The action to perform on each element</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
            {
                action(element);
            }
        }

        /// <summary>
        /// Checks if this enumerable contains zero elements.
        /// </summary>
        /// <param name="enumerable">The original enumerable</param>
        /// <returns><see langword="true"/> if the list count equals zero.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        /// <summary>
        /// Checks if this enumerable contains any elements.
        /// </summary>
        /// <param name="enumerable">The original enumerable</param>
        /// <returns><see langword="true"/> if the enumerable count is greater than zero</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any();
        }

        /// <summary>
        /// Creates a new array that contains this enumerable's elements.
        /// </summary>
        /// <param name="enumerable">The original enumerable</param>
        /// <returns>An array with values from this enumerable</returns>
        public static T[] ToArray<T>(this IEnumerable<T> enumerable)
        {
            return Enumerable.ToArray(enumerable);
        }
    }
}