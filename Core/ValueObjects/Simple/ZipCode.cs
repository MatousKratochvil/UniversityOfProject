using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct ZipCode : IStringValueObject
{
	public string Value { get; }

	private ZipCode(string value)
	{
		Value = value;
	}

	public static ZipCode Create(string value, ZipCodeValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(ZipCode));

		return new ZipCode(value);
	}

	private static ZipCodeValidator BasicValidator =>
		(value, propertyName) => Guard.BasicStringValidator(value, 5, 5, propertyName);

	public static implicit operator string(ZipCode value) => value.Value;
}

public delegate void ZipCodeValidator(string value, string? propertyName = null);