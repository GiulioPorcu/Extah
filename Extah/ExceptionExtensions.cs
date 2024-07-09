namespace Extah
{
    /// <summary>
    /// Provides extensions to <see cref="Exception"/> objects.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns the innermost <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception">The original exception</param>
        /// <returns>The innermost <see cref="Exception"/></returns>
        public static Exception Unwrap(this Exception exception)
        {
            Exception innermost = exception;

            while (innermost.InnerException != null)
            {
                innermost = innermost.InnerException;
            }

            return innermost;
        }
    }
}