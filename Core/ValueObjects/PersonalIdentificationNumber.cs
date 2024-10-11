using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct PersonalIdentificationNumber : IStringValueObject
{
    public string Value { get; }

    public PersonalIdentificationNumber(string value, PersonalIdentificationNumberValidator validator,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }

    public PersonalIdentificationNumber(string value)
    {
        Guard.ThrowWhenNullOrWhiteSpace(value, nameof(value));
        Value = value;
    }

    public static implicit operator string(PersonalIdentificationNumber name) => name.Value;
}

public delegate void PersonalIdentificationNumberValidator(string value, string? propertyName = null);