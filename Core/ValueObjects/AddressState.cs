using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct AddressState : IStringValueObject
{
    public string Value { get; }

    public AddressState(string value, StateValidator validator, [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }

    public static implicit operator string(AddressState name) => name.Value;
}

public delegate void StateValidator(string value, string? propertyName = null);