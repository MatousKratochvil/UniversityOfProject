using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct City : IStringValueObject
{
	public string Value { get; }

	private City(string value)
	{
		Value = value;
	}

	public static City Create(string value, CityValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(City));

		return new City(value);
	}
	
	internal static City Create(string value) => new(value);

	private static CityValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(City value) => value.Value;
}

public delegate void CityValidator(string value, string? propertyName = null);