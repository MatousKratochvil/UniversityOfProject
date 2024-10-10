using Core;
using Core.Persistence.Abstractions;
using Core.ValueObjects;

namespace HumanResources;

public sealed record RegularEmployee(
    EmployeeId Id,
    EmployeeNumber EmployeeNumber,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Employee(Id, "Regular", EmployeeNumber, Title, Name, Address, ContactInformation);

public sealed record AdministrativeEmployee(
    EmployeeId Id,
    EmployeeNumber EmployeeNumber,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Employee(Id, "Administrative", EmployeeNumber, Title, Name, Address, ContactInformation);

public sealed record Professor(
    EmployeeId Id,
    EmployeeNumber EmployeeNumber,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Employee(Id, "Professor", EmployeeNumber, Title, Name, Address, ContactInformation);

public record struct EmployeeId(Guid Id) : IEntityIdentity<Guid>
{
    public static implicit operator Guid(EmployeeId id) => id.Id;
}

public abstract record Employee(
    EmployeeId Id,
    string Type,
    EmployeeNumber EmployeeNumber,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Person(Title, Name, Address, ContactInformation);