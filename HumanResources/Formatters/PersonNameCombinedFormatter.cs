using Core.Abstractions;
using Core.ComplexObjects;

namespace HumanResources.Formatters;

public class PersonNameCombinedFormatter : IFormatter<PersonName>
{
	public static PersonNameCombinedFormatter Instance { get; } = new();

	public string Format(PersonName obj)
		=> obj.MiddleName is not null
			? $"{(string)obj.FirstName} {(string)obj.MiddleName} {(string)obj.LastName}"
			: $"{(string)obj.FirstName} {(string)obj.LastName}";
}