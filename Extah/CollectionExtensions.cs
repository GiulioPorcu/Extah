using System.Collections;

namespace Extah;

/// <summary>
/// Provides extensions for <see cref="ICollection"/> objects.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Concatenates this and another collection.
    /// <br></br><br></br>
    /// <see cref="ArgumentNullException"/> - if the other collection is null.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    /// <param name="values">Another collection of values to be added.</param>
    public static void Append<T>(this ICollection<T> collection, ICollection<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (T element in values)
        {
            collection.Add(element);
        }
    }

    /// <summary>
    /// Traverses the collection and checks if the value is within.
    /// <br></br><br></br>
    /// <see cref="ArgumentNullException"/> - if the value is <tt>null</tt>.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    /// <param name="value">The element to look out for.</param>
    public static bool Contains<T>(this ICollection<T> collection, T value)
    {
        ArgumentNullException.ThrowIfNull(value);

        foreach (T element in collection)
        {
            if (value.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Performs the specified action for each member in this object.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    /// <param name="action">The action to perform on each element.</param>
    public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }

    /// <summary>
    /// Checks if this collection contains zero elements.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
    }

    /// <summary>
    /// Checks if this collection contains any elements.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    public static bool IsNotEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count > 0;
    }

    /// <summary>
    /// Tries to remove all values from the other collection.
    /// </summary>
    /// <param name="collection">The original collection.</param>
    /// <param name="values">A collection of objects.</param>
    public static void Remove<T>(this ICollection<T> collection, ICollection<T> values)
    {
        foreach (T element in values)
        {
            collection.Remove(element);
        }
    }

    /// <summary>
    /// Creates a new array that contains this collection's elements.
    /// </summary>
    /// <param name="enumerable">The original collection.</param>
    public static T[] ToArray<T>(this ICollection<T> enumerable)
    {
        return Enumerable.ToArray(enumerable);
    }
}