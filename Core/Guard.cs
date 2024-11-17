using System.Runtime.CompilerServices;

namespace Core;

/// <summary>
/// Guard clauses to check the validity of the input.
/// </summary>
public static class Guard
{
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

	public static void ThrowWhenNullEmptyOrWhiteSpace(string value,
		[CallerArgumentExpression("value")] string? name = null)
	{
		if (string.IsNullOrWhiteSpace(value))
			throw new ArgumentException($"{name} must not be null, empty, or white space.");
	}

	public static void BasicStringValidator(string value, string? propertyName = null)
	{
		ThrowWhenNullEmptyOrWhiteSpace(value, propertyName);
		ThrowWhenOutOfLengthRange(value, 2, 50, propertyName);
	}

	public static void BasicStringValidator(string value, int min, int max, string? propertyName = null)
	{
		ThrowWhenNullEmptyOrWhiteSpace(value, propertyName);
		ThrowWhenOutOfLengthRange(value, min, max, propertyName);
	}

	public static void BasicDateValidator(DateOnly value, string? propertyName)
	{
		if (value == DateOnly.MinValue)
			throw new ArgumentException($"{propertyName} must not be the default value.");
	}

	public static void BasicEmailValidator(string value, string? propertyname)
	{
		ThrowWhenNullEmptyOrWhiteSpace(value, propertyname);
		ThrowWhenOutOfLengthRangeIgnoreNull(value, 5, 254, propertyname);
		if (!value.Contains('@') || !value.Contains('.'))
			throw new ArgumentException($"{propertyname} must be a valid email address.");
	}

	public static void BasicPhoneNumberValidator(string value, string? propertyname)
	{
		ThrowWhenNullEmptyOrWhiteSpace(value, propertyname);
		ThrowWhenOutOfLengthRangeIgnoreNull(value, 5, 20, propertyname);
		if (!value.All(char.IsDigit))
			throw new ArgumentException($"{propertyname} must contain only digits.");
	}
}