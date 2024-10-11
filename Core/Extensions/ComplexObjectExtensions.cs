using Core.Abstractions;

namespace Core.Extensions;

public static class ComplexObjectExtensions
{
	public static string Format<T>(this T obj, IFormatter<T> formatter) where T : IComplexObject
		=> formatter.Format(obj);
}