using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct PhoneNumber : IStringValueObject
{
	public string Value { get; }

	private PhoneNumber(string value)
	{
		Value = value;
	}

	public static PhoneNumber Create(string value, PhoneNumberValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(PhoneNumber));

		return new PhoneNumber(value);
	}

	internal static PhoneNumber Create(string value) => new(value);
	
	private static PhoneNumberValidator BasicValidator => Guard.BasicPhoneNumberValidator;

	public static implicit operator string(PhoneNumber value) => value.Value;
}

public delegate void PhoneNumberValidator(string value, string? propertyName = null);