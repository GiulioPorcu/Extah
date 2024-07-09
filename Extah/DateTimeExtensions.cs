namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="DateTime"/> objects.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns this object formatted as hh:mm:ss.
        /// </summary>
        /// <param name="dateTime">The original <see cref="DateTime"/></param>
        /// <returns>The time as a string</returns>
        public static string GetTimeString(this DateTime dateTime)
        {
            return $"{dateTime.Hour:D2}:{dateTime.Minute:D2}:{dateTime.Second:D2}";
        }

        /// <summary>
        /// Returns this object formatted as dd.mm.yyyy.
        /// </summary>
        /// <param name="dateTime">The original <see cref="DateTime"/></param>
        /// <returns>The date as a string</returns>
        public static string GetDateString(this DateTime dateTime)
        {
            return $"{dateTime.Day:D2}.{dateTime.Month:D2}.{dateTime.Year:D4}";
        }

        /// <summary>
        /// Gets the current time in format "dd.MM.yy hh:mm:ss".
        /// </summary>
        /// <param name="dateTime">The original <see cref="DateTime"/></param>
        /// <returns>The date and time as a string</returns>
        public static string GetCurrentDateTimeString1(this DateTime dateTime)
        {
            int year = dateTime.Year % 100;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int hour = dateTime.Hour;
            int min = dateTime.Minute;
            int sec = dateTime.Second;

            return $"{day:D2}.{month:D2}.{year} {hour:D2}:{min:D2}:{sec:D2}";
        }

        /// <summary>
        /// Gets the current time in format "yyyy-MM-dd HH:mm:ss".
        /// </summary>
        /// <param name="dateTime">The original <see cref="DateTime"/></param>
        /// <returns>The date and time as a string</returns>
        public static string GetCurrentDateTimeString2(this DateTime dateTime)
        {
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int hour = dateTime.Hour;
            int min = dateTime.Minute;
            int sec = dateTime.Second;

            return $"{year}-{month:D2}-{day:D2} {hour:D2}:{min:D2}:{sec:D2}";
        }

        /// <summary>
        /// Gets the current time in format "yyyyMMdd_HHmmss".
        /// </summary>
        /// <param name="dateTime">The original <see cref="DateTime"/></param>
        /// <returns>The date and time as a string</returns>
        public static string GetCurrentDateTimeString3(this DateTime dateTime)
        {
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int hour = dateTime.Hour;
            int min = dateTime.Minute;
            int sec = dateTime.Second;

            return $"{year:D4}{month:D2}{day:D2}_{hour:D2}{min:D2}{sec:D2}";
        }
    }
}