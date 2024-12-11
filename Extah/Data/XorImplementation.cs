namespace Extah.Data;

/// <summary>
/// Provides named constants for different XOR implementations.
/// </summary>
public enum XorImplementation
{
    /// <summary>
    /// No implementation.
    /// </summary>
    None,

    /// <summary>
    /// If for all XOR inputs one and exactly one is true.
    /// </summary>
    Exactly1,

    /// <summary>
    /// If an odd number of inputs is true.
    /// </summary>
    Parity
}