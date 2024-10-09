using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct ZipCode : IStringValueObject
{
    public string Value { get; }

    public ZipCode(string value, ZipCodeValidator validator, Regex letterChecker, [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Guard.ThrowWhenRegexMatch(value, letterChecker, "Zip code cannot contain letters", name);
        Value = value;
    }

    public static implicit operator string(ZipCode name) => name.Value;
}

public delegate void ZipCodeValidator(string value, string? propertyName = null);