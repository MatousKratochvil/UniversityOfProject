using Core;
using Core.Persistence.Abstractions;
using Core.ValueObjects;

namespace HumanResources;

public record struct AdministrativeEmployeeId(Guid Id) : IEntityIdentity<Guid>
{
    public static implicit operator Guid(AdministrativeEmployeeId id) => id.Id;
}

public sealed record AdministrativeEmployee(
    AdministrativeEmployeeId Id,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Person(Title, Name, Address, ContactInformation);

public record struct EmployeeId(Guid Id) : IEntityIdentity<Guid>
{
    public static implicit operator Guid(EmployeeId id) => id.Id;
}

public sealed record Employee(
    EmployeeId Id,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Person(Title, Name, Address, ContactInformation);

public record struct ProfessorId(Guid Id) : IEntityIdentity<Guid>
{
    public static implicit operator Guid(ProfessorId id) => id.Id;
}

public sealed record Professor(
    ProfessorId Id,
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation)
    : Person(Title, Name, Address, ContactInformation);