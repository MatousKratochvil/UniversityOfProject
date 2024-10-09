using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public readonly struct SingleName : IStringValueObject
{
    public string Value { get; }

    public SingleName(string value, SingleNameValidator validator,
        [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Guard.ThrowWhenContainsWhiteSpace(value, name);
        Value = value;
    }

    public static implicit operator string(SingleName singleName) => singleName.Value;
}

public delegate void SingleNameValidator(string value, string? propertyName = null);