using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct MiddleName : IStringValueObject
{
	public string Value { get; }

	private MiddleName(string value)
	{
		Value = value;
	}

	public static MiddleName Create(string value, MiddleNameValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(MiddleName));

		return new MiddleName(value);
	}

	internal static MiddleName Create(string value) => new(value);
	
	private static MiddleNameValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(MiddleName value) => value.Value;
}

public delegate void MiddleNameValidator(string value, string? propertyName = null);