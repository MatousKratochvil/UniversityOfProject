using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Core.ValueObjects;

namespace Core;

/// <summary>
/// Guard clauses to check the validity of the input.
/// </summary>
public static class Guard
{
    public static void ThrowWhenContainsWhiteSpace(string? value,
        [CallerArgumentExpression("value")] string? name = null)
        => ThrowWhenContains(value, " ", name);
    
    public static void ThrowWhenRegexMatch(string? value, Regex regex,
        string? message = null,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is not null && regex.IsMatch(value))
            throw new ArgumentException(message ?? $"Invalid {name}.", name);
    }

    public static void ThrowWhenContains(string? value, string contains,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is not null && value.Contains(contains, StringComparison.Ordinal))
            throw new ArgumentException($"{name} must not contain '{contains}'.");
    }

    public static void ThrowWhenNullOrWhiteSpace(string? value, [CallerArgumentExpression("value")] string? name = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{name} must not be null or empty.");
    }

    public static void ThrowWhenSmallerLength(string? value, int length,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is null || value.Length < length)
            throw new ArgumentException($"{name} must be at least {length} characters long.");
    }

    public static void ThrowWhenSmallerLengthIgnoreNull(string? value, int length,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is not null && value.Length < length)
            throw new ArgumentException($"{name} must be at least {length} characters long.");
    }

    public static void ThrowWhenOutOfLengthRange(string? value, int minLength, int maxLength,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is null || value.Length < minLength || value.Length > maxLength)
            throw new ArgumentException($"{name} must be between {minLength} and {maxLength} characters long.");
    }

    public static void ThrowWhenOutOfLengthRangeIgnoreNull(string? value, int minLength, int maxLength,
        [CallerArgumentExpression("value")] string? name = null)
    {
        if (value is not null && (value.Length < minLength || value.Length > maxLength))
            throw new ArgumentException($"{name} must be between {minLength} and {maxLength} characters long.");
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