using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct PersonTitle : IStringValueObject
{
    public string Value { get; }

    public PersonTitle(string value, PersonTitleValidator validator,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }

    public static implicit operator string(PersonTitle name) => name.Value;
}

public delegate void PersonTitleValidator(string value, string? propertyName = null);