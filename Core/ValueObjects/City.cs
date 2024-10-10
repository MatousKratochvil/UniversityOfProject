using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct City : IStringValueObject
{
    public string Value { get; }

    public City(string value, CityValidator validator,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }

    public City(string value)
    {
        Guard.ThrowWhenNullOrWhiteSpace(value, nameof(value));
        Value = value;
    }

    public static implicit operator string(City name) => name.Value;
}

public delegate void CityValidator(string value, string? propertyName = null);