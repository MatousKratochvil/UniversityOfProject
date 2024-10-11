using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Core;

/// <summary>
/// Guard clauses to check the validity of the input.
/// </summary>
public static class Guard
{
	public static void ThrowWhenContainsWhiteSpace(string? value, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
		=> ThrowWhenContains(value, " ", message, name);

	public static void ThrowWhenRegexNotMatch(string? value, Regex regex, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is not null && !regex.IsMatch(value))
			throw new ArgumentException(message ?? $"Invalid {name}.", name);
	}

	public static void ThrowWhenContains(string? value, string contains, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is not null && value.Contains(contains, StringComparison.Ordinal))
			throw new ArgumentException(message ?? $"{name} must not contain '{contains}'.");
	}

	public static void ThrowWhenDefault<T>(T value, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (EqualityComparer<T>.Default.Equals(value, default))
			throw new ArgumentException(message ?? $"{name} must not be the default value.");
	}

	public static void ThrowWhenNullOrDefault<T>(T? value, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is null || EqualityComparer<T>.Default.Equals(value, default))
			throw new ArgumentException(message ?? $"{name} must not be null or the default value.");
	}

	public static void ThrowWhenNullOrWhiteSpace(string? value, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (string.IsNullOrWhiteSpace(value))
			throw new ArgumentException(message ?? $"{name} must not be null or empty.");
	}

	public static void ThrowWhenSmallerLength(string? value, int length, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is null || value.Length < length)
			throw new ArgumentException(message ?? $"{name} must be at least {length} characters long.");
	}

	public static void ThrowWhenSmallerLengthIgnoreNull(string? value, int length, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is not null && value.Length < length)
			throw new ArgumentException(message ?? $"{name} must be at least {length} characters long.");
	}

	public static void ThrowWhenOutOfLengthRange(string? value, int minLength, int maxLength, string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is null || value.Length < minLength || value.Length > maxLength)
			throw new ArgumentException(message ??
			                            $"{name} must be between {minLength} and {maxLength} characters long.");
	}

	public static void ThrowWhenOutOfLengthRangeIgnoreNull(string? value, int minLength, int maxLength,
		string? message = null,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (value is not null && (value.Length < minLength || value.Length > maxLength))
			throw new ArgumentException(message ??
			                            $"{name} must be between {minLength} and {maxLength} characters long.");
	}

	public static void ThrowWhenGreaterThen<T>(T value, T comparable) where T : IComparable<T> =>
		ThrowWhenGreaterThen(value, comparable, "The value must not be greater than the comparable value.");

	public static void ThrowWhenGreaterThen<T>(T value, T comparable, string? message = null,
		[CallerArgumentExpression("value")] string? name = null) where T : IComparable<T>
	{
		if (value.CompareTo(comparable) > 0)
			throw new ArgumentException(message ?? $"{name} must not be greater than {comparable}.");
	}

	public static void ThrowWhenGreaterOrEqualThen<T>(T value, T comparable) where T : IComparable<T> =>
		ThrowWhenGreaterOrEqualThen(value, comparable,
			"The value must not be greater or equal than the comparable value.");

	public static void ThrowWhenGreaterOrEqualThen<T>(T value, T comparable, string? message = null,
		[CallerArgumentExpression("value")] string? name = null) where T : IComparable<T>
	{
		if (value.CompareTo(comparable) >= 0)
			throw new ArgumentException(message ?? $"{name} must not be greater or equal than {comparable}.");
	}

	public static void ThrowWhenSmallerThen<T>(T value, T comparable) where T : IComparable<T> =>
		ThrowWhenSmallerThen(value, comparable, "The value must not be smaller than the comparable value.");

	public static void ThrowWhenSmallerThen<T>(T value, T comparable, string? message = null,
		[CallerArgumentExpression("value")] string? name = null) where T : IComparable<T>
	{
		if (value.CompareTo(comparable) < 0)
			throw new ArgumentException(message ?? $"{name} must not be smaller than {comparable}.");
	}

	public static void ThrowWhenSmallerOrEqualThen<T>(T value, T comparable) where T : IComparable<T> =>
		ThrowWhenSmallerOrEqualThen(value, comparable,
			"The value must not be smaller or equal than the comparable value.");

	public static void ThrowWhenSmallerOrEqualThen<T>(T value, T comparable, string? message = null,
		[CallerArgumentExpression("value")] string? name = null) where T : IComparable<T>
	{
		if (value.CompareTo(comparable) <= 0)
			throw new ArgumentException(message ?? $"{name} must not be smaller or equal than {comparable}.");
	}
}