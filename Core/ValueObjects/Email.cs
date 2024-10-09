using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct Email : IStringValueObject
{
    public string Value { get; }

    public Email(string value, EmailValidator validator, Regex emailRegex,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Guard.ThrowWhenRegexMatch(value, emailRegex, "Email is not valid", name);
        Value = value;
    }

    public static implicit operator string(Email name) => name.Value;
}

public delegate void EmailValidator(string value, string? propertyName = null);