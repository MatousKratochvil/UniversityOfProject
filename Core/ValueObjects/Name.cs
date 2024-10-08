using System.Runtime.CompilerServices;

namespace Core.ValueObjects;

public readonly struct Name
{
    private string Value { get; }

    internal Name(string value, NameValidator validator, [CallerArgumentExpression("value")] string? name = null)
    {
        validator(value, name);
        Value = value;
    }
    
    public static implicit operator string(Name name) => name.Value;
}

public delegate void NameValidator(string value, string? propertyName = null);