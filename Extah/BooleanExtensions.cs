using Extah.Data;
using Extah.Properties;

namespace Extah
{
    /// <summary>
    /// Provides extensions for <see cref="Boolean"/>.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Returns the result of the AND operation using this and other booleans. Returns the original boolean if there are no other values.
        /// </summary>
        /// <param name="boolean">The original boolean.</param>
        /// <param name="values">Any values to be ANDed.</param>
        public static bool And(this bool boolean, params bool[] values)
        {
            if (values == null || values.Length == 0)
            {
                return boolean;
            }

            if (boolean)
            {
                foreach (bool element in values)
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
        /// Returns the result of an OR operation using this and other booleans. Returns the original boolean if there are no other values.
        /// </summary>
        /// <param name="boolean">The original boolean.</param>
        /// <param name="values">Any values to be ORed.</param>
        public static bool Or(this bool boolean, params bool[] values)
        {
            if (values == null || values.Length == 0)
            {
                return boolean;
            }

            if (!boolean)
            {
                foreach (bool element in values)
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
        /// Returns the result of an XOR operation using this and other booleans.
        /// </summary>
        /// <param name="boolean">The original boolean value.</param>
        /// <param name="implementation">Determines how the XOR check should be performed.</param>
        /// <param name="values">Any values to be ORed.</param>
        public static bool Xor(this bool boolean, XorImplementation implementation, params bool[] values)
        {
            switch (implementation)
            {
                case XorImplementation.Parity:
                    {
                        bool result = boolean;

                        foreach (bool element in values)
                        {
                            result = result ^= element;
                        }

                        return result;
                    }

                case XorImplementation.Exactly1:
                    {
                        int count = boolean ? 1 : 0;

                        foreach (bool element in values)
                        {
                            if (count > 1)
                            {
                                return false;
                            }

                            count += element ? 1 : 0;
                        }

                        return count == 1;
                    }

                case XorImplementation.None:
                default:
                    throw new ArgumentException(Message.XorImplementationInvalid);
            }
        }
    }
}