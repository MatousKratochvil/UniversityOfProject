namespace Core;

/// <summary>
/// Optional type to represent a value that may or may not be present.
/// </summary>
/// <typeparam name="T"></typeparam>
public record struct OptionalType<T>
{
    private readonly T? _value;
    
    private OptionalType(T? value)
    {
        _value = value;
    }
    
    public static OptionalType<T> Of(T value) => new(value);
    
    public static OptionalType<T> Empty() => new(default);
}

public static class Optional
{
    public static OptionalType<T> Of<T>(T value) => OptionalType<T>.Of(value);
    
    public static OptionalType<T> Empty<T>() => OptionalType<T>.Empty();
}