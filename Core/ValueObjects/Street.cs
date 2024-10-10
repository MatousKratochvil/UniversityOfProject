using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct Street : IStringValueObject
{
    public string Value { get; }

    public Street(string value, StreetValidator validator,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }
    
    public Street(string value)
    {
        Guard.ThrowWhenNullOrWhiteSpace(value);
        Value = value;
    }

    public static implicit operator string(Street name) => name.Value;
}

public delegate void StreetValidator(string value, string? propertyName = null);