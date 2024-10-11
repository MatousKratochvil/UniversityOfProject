using Core.ComplexObjects;
using Core.ValueObjects;
using HumanResources.Abstractions;
using HumanResources.Entities;

namespace HumanResources;

internal class HumanResourceFactory : IHumanResourceFactory
{
    public Employee CreateEmployee(EmployeePrimitiveValues primitiveValues)
        => primitiveValues.Type switch
        {
            "Professor" => new Professor(EmployeeId.Empty, CreatePerson(primitiveValues), null),
            "Administrative" => new AdministrativeEmployee(EmployeeId.Empty, CreatePerson(primitiveValues), null),
            "Regular" => new RegularEmployee(EmployeeId.Empty, CreatePerson(primitiveValues), null),
            _ => throw new ArgumentOutOfRangeException(nameof(primitiveValues.Type))
        };

    public Person CreatePerson(EmployeePrimitiveValues primitiveValues) =>
        new(
            new Title(primitiveValues.Title),
            new PersonName(new SingleName(primitiveValues.FirstName), null, new SingleName(primitiveValues.LastName)),
            new PersonIdentification(new BirthDate(primitiveValues.BirthDate),
                new PersonalIdentificationNumber(primitiveValues.PersonalIdentificationNumber)),
            new Address(new Street(primitiveValues.Street), new City(primitiveValues.City),
                new State(primitiveValues.State), new ZipCode(primitiveValues.ZipCode)),
            new ContactInformation(new Email(primitiveValues.Email), new PhoneNumber(primitiveValues.PhoneNumber)));
}