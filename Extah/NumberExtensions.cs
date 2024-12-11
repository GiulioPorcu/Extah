namespace Extah;

/// <summary>
/// Provides extensions to numbers.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Returns the factorial for this integer or 1 if this number is less than or equal to 1.
    /// </summary>
    /// <param name="num">The original number.</param>
    public static long Factorial(this int num)
    {
        int result = 1;

        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    /// Determines if this integer is a prime number.
    /// </summary>
    /// <param name="num">The original number.</param>
    public static bool IsPrime(this int num)
    {
        return num < 3 ? num == 2 : Enumerable.Range(2, (int)Math.Sqrt(num)).All(m => num % m != 0);
    }

    /// <summary>
    /// Trims this double value to fit the amount of decimal places.
    /// <br></br><br></br>
    /// <see cref="ArgumentOutOfRangeException"/> - if the value for decimal places is smaller than zero.
    /// </summary>
    /// <param name="num">The original number.</param>
    /// <param name="decimalPlaces">The amount of decimal places.</param>
    public static double RoundDecimalPlaces(this double num, int decimalPlaces)
    {
        return decimalPlaces < 0 ? throw new ArgumentOutOfRangeException(nameof(decimalPlaces)) : Math.Round(num, decimalPlaces);
    }

    /// <summary>
    /// Takes this double to the power of the exponent.
    /// </summary>
    /// <param name="num">The original number.</param>
    /// <param name="exponent">A valid exponent.</param>
    /// <returns>The result of the power operation.</returns>
    public static double ToThePowerOf(this double num, double exponent)
    {
        return Math.Pow(num, exponent);
    }
}