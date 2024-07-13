namespace Extah
{
    /// <summary>
    /// Provides extensions for <see cref="Exception"/> objects.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns the innermost <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception">The original exception.</param>
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