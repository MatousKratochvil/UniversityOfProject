using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct EmailAddress : IStringValueObject
{
	public string Value { get; }

	private EmailAddress(string value)
	{
		Value = value;
	}
	
	public static EmailAddress Create(string value, EmailAddressValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(EmailAddress));

		return new EmailAddress(value);
	}
	
	private static EmailAddressValidator BasicValidator => Guard.BasicEmailValidator;
	
	public static implicit operator string(EmailAddress value) => value.Value;
}

public delegate void EmailAddressValidator(string value, string? propertyName = null);
