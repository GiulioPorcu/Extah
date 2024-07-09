namespace Extah
{
    /// <summary>
    /// Provides extensions for any object.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns a list of names of all interfaces this object implements.
        /// </summary>
        /// <param name="obj">The original object</param>
        /// <returns>A collection of interface names</returns>
        public static IList<string> GetInterfaceNames(this object obj)
        {
            List<string> interfaces = new List<string>();

            foreach (Type type in obj.GetType().GetInterfaces())
            {
                // Note: The parameter " `1 " is used intentionally.
                interfaces.Add(type.Name.Replace("`1", "<T>"));
            }

            return interfaces;
        }
    }
}