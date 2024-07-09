namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="bool"/> objects.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Returns the result of the AND operation using this and other booleans.
        /// </summary>
        /// <param name="boolean">The original boolean.</param>
        /// <param name="parameters">A variable array of boolean values.</param>
        public static bool And(this bool boolean, params bool[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return boolean;
            }

            if (boolean)
            {
                foreach (bool element in parameters)
                {
                    if (!element)
                    {
                        return false;
                    }
                }
            }

            return boolean;
        }

        /// <summary>
        /// Returns the result of an OR operation using this and other booleans.
        /// </summary>
        /// <param name="boolean">The original boolean.</param>
        /// <param name="parameters">A variable array of boolean values.</param>
        public static bool Or(this bool boolean, params bool[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return boolean;
            }

            if (!boolean)
            {
                foreach (bool element in parameters)
                {
                    if (element)
                    {
                        return true;
                    }
                }
            }

            return boolean;
        }

        /// <summary>
        /// Returns the result of an XOR operation using this and other booleans in succession. The result of the former operation will be
        /// used as the input for the next expression.
        /// </summary>
        /// <param name="boolean">The original boolean value.</param>
        /// <param name="parameters">A variable array of boolean values.</param>
        /// <example>(true, true, true) will equal true since (true, true) equals false and the resulting (false) and the last (true) equal
        /// true.
        /// </example>
        public static bool Xor(this bool boolean, params bool[] parameters)
        {
            bool result = boolean;

            foreach (bool element in parameters)
            {
                result = result ^= element;
            }

            return result;
        }
    }
}