using Core.Abstractions;
using Core.ComplexObjects;

namespace BlazorApp;

public class CombinedNameFormatter : IFormatter<PersonName>
{
	public static CombinedNameFormatter Instance { get; } = new();

	public string Format(PersonName obj)
		=> obj.MiddleName is not null
			? $"{(string)obj.FirstName} {(string)obj.MiddleName} {(string)obj.LastName}"
			: $"{(string)obj.FirstName} {(string)obj.LastName}";
}