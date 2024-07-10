using System.Text;

namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="Random"/> objects.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns either <see langword="true"/> or <see langword="false"/> at 50/50 odds.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <returns><see langword="true"/> or <see langword="false"/> at 50/50 odds</returns>
        public static bool NextBoolean(this Random random)
        {
            return random.Next(2) == 0;
        }

        /// <summary>
        /// Creates an array of random bytes with the specified size.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <param name="arraySize">The amount of bytes the sequence should return</param>
        /// <returns>An array of random byte values</returns>
        public static byte[] NextBytes(this Random random, int arraySize)
        {
            byte[] buffer = new byte[arraySize];
            random.NextBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <returns>A non-negative random integer</returns>
        public static int NextInt(this Random random)
        {
            return random.Next();
        }

        /// <summary>
        /// Returns a random integer in the specified range.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The upper boundary</param>
        /// <returns>A random integer</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the minimum value is bigger than the maximum</exception>
        public static int NextInt(this Random random, int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// Returns a random integer between -2^32 and 2^32-1.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <returns>A random integer</returns>
        public static int NextIntSigned(this Random random)
        {
            return random.Next(Int32.MinValue, Int32.MaxValue);
        }

        /// <summary>
        /// Returns a random double in the specified range.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The upper boundary</param>
        /// <returns>A random double value</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the minimum value is bigger than the maximum</exception>
        public static double NextDouble(this Random random, double min, double max)
        {
            return (random.NextDouble() * (max - min)) + min;
        }

        /// <summary>
        /// Returns a random double between -1.7976931348623157E+308 and 1.7976931348623157E+308.
        /// </summary>
        /// <param name="random">The original random instance</param>
        /// <returns>A random double value</returns>
        public static double NextDoubleSigned(this Random random)
        {
            return random.NextDouble(Double.MinValue, Double.MaxValue);
        }

        public static string NextString(this Random random, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(random.Next() % 2 == 0 ? (char)random.Next('A', 'Z') : (char)random.Next('a', 'z'));
            }

            return stringBuilder.ToString();
        }
    }
}