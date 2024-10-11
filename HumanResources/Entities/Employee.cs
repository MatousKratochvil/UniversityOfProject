using Core;
using Core.Persistence.Abstractions;

namespace HumanResources.Entities;

public record struct EmployeeId(Guid Id) : IEntityIdentity<Guid>
{
    public EmployeeId(string id)
        : this(Guid.Parse(id))
    {
    }
    
    public static implicit operator Guid(EmployeeId id) => id.Id;
    public static EmployeeId Empty => new(Guid.Empty);
}

public sealed class RegularEmployee(EmployeeId id, Person person, EmploymentContract contract)
    : Employee(id, person, contract)
{
    private RegularEmployee()
        : this(default, default, default)
    {
    }
}

public sealed class AdministrativeEmployee(EmployeeId id, Person person, EmploymentContract contract)
    : Employee(id, person, contract)
{
    private AdministrativeEmployee()
        : this(default, default, default)
    {
    }
}

public sealed class Professor(EmployeeId id, Person person, EmploymentContract contract)
    : Employee(id, person, contract)
{
    private Professor()
        : this(default, default, default)
    {
    }
}

public abstract class Employee(EmployeeId id, Person person, EmploymentContract contract)
    : IEntity<EmployeeId, Guid>
{
    public EmployeeId Id { get; } = id;
    public Person Person { get; } = person;
    public EmploymentContract Contract { get; } = contract;
}