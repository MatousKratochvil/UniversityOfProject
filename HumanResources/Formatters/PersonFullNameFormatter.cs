using Core.Abstractions;
using Core.ComplexObjects;
using Core.ValueObjects;

namespace HumanResources.Formatters;

public class PersonFullNameFormatter : IFormatter<Person>
{
    public static PersonFullNameFormatter Instance { get; } = new();

    private PersonFullNameFormatter()
    {
    }

    public string Format(Person obj) =>
        $"{GetTitle(obj.Title)}{GetName(obj.Name)}";

    private string GetTitle(Title? objTitle) =>
        objTitle is null
            ? string.Empty
            : (string)objTitle + ". ";

    private string GetName(PersonName objName) =>
        objName.MiddleName is not null
            ? $"{(string)objName.FirstName} {(string)objName.MiddleName} {(string)objName.LastName}"
            : $"{(string)objName.FirstName} {(string)objName.LastName}";
}