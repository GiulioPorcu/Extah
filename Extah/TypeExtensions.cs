using System.Reflection;

namespace Extah;

/// <summary>
/// Provides extensions to <see cref="Type"/> objects.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Returns a collection of all fields with the specified flags and fulfilling the <see cref="FieldInfo"/> predicate.
    /// </summary>
    /// <param name="type">The type for a object</param>
    /// <param name="flags">The binding flags for the specified fields</param>
    /// <param name="predicate">The predicate to check each field for</param>
    /// <returns>An <see cref="IList{T}"/> containing the requested members</returns>
    public static IList<object> GetFields(this Type type, BindingFlags flags, Func<FieldInfo, bool> predicate)
    {
        List<object> returnFields = [];
        FieldInfo[] fields = type.GetFields(flags);

        foreach (FieldInfo field in fields.Where(predicate))
        {
            returnFields.Add(field.GetValue(null));
        }

        return returnFields;
    }
}