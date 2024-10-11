using Core.Abstractions;

namespace Core.Extensions;

public static class ValueObjectExtensions
{
    public static string Format<T>(this T obj, IFormatter<T> formatter) where T : IValueObject
        => formatter.Format(obj);
}