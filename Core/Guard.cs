using System.Runtime.CompilerServices;

namespace Core;

/// <summary>
/// Guard clauses to check the validity of the input.
/// </summary>
public static class Guard
{
    public static void ThrowWhenSmallerLength(string value, int length,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value.Length < length)
        {
            throw new ArgumentException($"{name} must be at least {length} characters long.");
        }
    }

    public static void ThrowWhenSmallerLengthIgnoreNull(string? value, int length,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is not null && value.Length < length)
        {
            throw new ArgumentException($"{name} must be at least {length} characters long.");
        }
    }
}

public static class GuardOptional
{
    public static OptionalType<string> WhenSmallerLength(string value, int length,
        [CallerArgumentExpression("value")] string? name = null)
        =>
            value.Length < length ? Optional.Empty<string>() : Optional.Of(value);

    public static OptionalType<string> WhenSmallerLengthIgnoreNull(string? value, int length,
        [CallerArgumentExpression("value")] string? name = null)
        =>
            value is not null && value.Length < length
                ? Optional.Empty<string>()
                : value is null
                    ? Optional.Of(string.Empty)
                    : Optional.Of(value);
}