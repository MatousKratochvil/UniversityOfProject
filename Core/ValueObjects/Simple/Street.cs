using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct Street : IStringValueObject
{
	public string Value { get; }

	private Street(string value)
	{
		Value = value;
	}

	public static Street Create(string value, StreetValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(Street));

		return new Street(value);
	}

	private static StreetValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(Street value) => value.Value;
}

public delegate void StreetValidator(string value, string? propertyName = null);