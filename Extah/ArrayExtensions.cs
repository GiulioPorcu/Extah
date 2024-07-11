using Extah.Data;
using Extah.Properties;

namespace Extah
{
    /// <summary>
    /// Provides extensions for <see cref="Array"/>.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Adds values to the end of this array, creating a new instance. Returns the original array if there are no other values.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="values">Any values to be added.</param>
        public static T[] Append<T>(this T[] array, params T[] values)
        {
            if (values == null || values.Length == 0)
            {
                return array;
            }

            T[] newArray = new T[array.Length + values.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = 0; i < values.Length; i++)
            {
                newArray[array.Length + i] = values[i];
            }

            return newArray;
        }

        /// <summary>
        /// Traverses the array and checks if the requested value is within.
        /// <br></br><br></br>
        /// <see cref="ArgumentNullException"/> - if the value is <tt>null</tt>.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="value">The element to look out for.</param>
        public static bool Contains<T>(this T[] array, T value)
        {
            return IndexOf(array, value) >= 0;
        }

        /// <summary>
        /// Traverses the array and returns the value's index or -1 if not found. If the value appears multiple times, returns the first occurrence.
        /// <br></br><br></br>
        /// <see cref="ArgumentNullException"/> - if the value is <tt>null</tt>.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="value">The element to be looked for.</param>
        public static int IndexOf<T>(this T[] array, T value)
        {
            ArgumentNullException.ThrowIfNull(value);

            for (int i = 0; i < array.Length; i++)
            {
                if (value.Equals(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Checks if this array is sorted.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the sorting order is not a valid value.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="sortOrder">The sorting order.</param>
        public static bool IsSorted<T>(this T[] array, SortOrder sortOrder = SortOrder.Ascending) where T : IComparable
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    {
                        for (int i = 1; i < array.Length; i++)
                        {
                            if (array[i].CompareTo(array[i - 1]) < 0)
                            {
                                return false;
                            }
                        }

                        break;
                    }

                case SortOrder.Descending:
                    {
                        for (int i = 1; i < array.Length; i++)
                        {
                            if (array[i].CompareTo(array[i - 1]) > 0)
                            {
                                return false;
                            }
                        }

                        break;
                    }

                case SortOrder.None:
                default:
                    throw new ArgumentException(Message.SortOrderInvalid);
            }

            return true;
        }

        /// <summary>
        /// Returns the lowest value of the array.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the array's length is zero.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static T Min<T>(this T[] array) where T : IComparable
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(Message.ArrayEmpty);
            }

            T min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the biggest value of the array.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the array's length is zero.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static T Max<T>(this T[] array) where T : IComparable
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(Message.ArrayEmpty);
            }

            T max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Removes the specified element by creating a new array without it.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the array is empty or the index is not valid for this array.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="index">An index.</param>
        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(Message.ArrayEmpty);
            }

            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentException(Message.IndexInvalid);
            }

            if (array.Length == 1)
            {
                return [];
            }

            T[] newArray = new T[array.Length - 1];

            int i = 0;
            int j = 0;

            while (i < array.Length)
            {
                if (i != index)
                {
                    newArray[j] = array[i];
                    j++;
                }

                i++;
            }

            return newArray;
        }

        /// <summary>
        /// Removes the first element by creating a new array without it.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the array is empty.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static T[] RemoveFirst<T>(this T[] array)
        {
            return RemoveAt(array, 0);
        }

        /// <summary>
        /// Removes the last element by creating a new array without it.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the array is empty.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static T[] RemoveLast<T>(this T[] array)
        {
            return RemoveAt(array, array.Length - 1);
        }

        /// <summary>
        /// Shuffles this array's content using a modified Fisher-Yates shuffle, or leaves it as is if less than two elements are available.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static void Shuffle<T>(this T[] array)
        {
            if (array.Length > 1)
            {
                Random random = new Random();

                for (int i = array.Length - 1; i >= 0; i--)
                {
                    int index1 = (int)(random.NextDouble() * i);
                    int index2 = (int)(random.NextDouble() * i);

                    Swap(array, index1, index2);
                }
            }
        }

        /// <summary>
        /// Uses Microsoft's native sort function and sorts this array.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="comparer">An optional comparer to use when comparing objects.</param>
        public static void Sort<T>(this T[] array, IComparer<T>? comparer = default) where T : IComparable
        {
            if (comparer == null)
            {
                Array.Sort(array);
            }
            else
            {
                Array.Sort(array, comparer);
            }
        }

        /// <summary>
        /// Uses Microsoft's native sort function and sorts this array.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="comparison">An optional comparison to use when comparing objects.</param>
        public static void Sort<T>(this T[] array, Comparison<T>? comparison = default) where T : IComparable
        {
            if (comparison == null)
            {
                Array.Sort(array);
            }
            else
            {
                Array.Sort(array, comparison);
            }
        }

        /// <summary>
        /// Swaps two values inside the array.
        /// <br></br><br></br>
        /// <see cref="ArgumentException"/> - if the index values are not valid for this array.
        /// </summary>
        /// <param name="array">The original array.</param>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            if (index1 < 0 || index1 >= array.Length)
            {
                throw new ArgumentException(String.Format(Message.SpecificIndexInvalid, nameof(index1)));
            }

            if (index2 < 0 || index2 >= array.Length)
            {
                throw new ArgumentException(String.Format(Message.SpecificIndexInvalid, nameof(index2)));
            }

            (array[index1], array[index2]) = (array[index2], array[index1]);
        }

        /// <summary>
        /// Copies all contents from this array into a new <see cref="List{T}"/> of the same size and type.
        /// </summary>
        /// <param name="array">The original array.</param>
        public static IList<T> ToList<T>(this T[] array)
        {
            return new List<T>(array);
        }
    }
}