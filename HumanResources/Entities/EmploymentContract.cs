using Core.Persistence.Abstractions;

namespace HumanResources.Entities;

public record struct EmploymentContractId(Guid Id) : IEntityIdentity<Guid>
{
    public EmploymentContractId(string id)
        : this(Guid.Parse(id))
    {
    }

    public static implicit operator Guid(EmploymentContractId id) => id.Id;
    public static EmploymentContractId Empty => new(Guid.Empty);
}

public sealed class TemporaryContract(
    EmploymentContractId id,
    EmployeeId employeeId,
    Employee employee)
    : EmploymentContract(id, employeeId, employee)
{
    private TemporaryContract()
        : this(default, default, default)
    {
    }
}

public sealed class PermanentContract(
    EmploymentContractId id,
    EmployeeId employeeId,
    Employee employee)
    : EmploymentContract(id, employeeId, employee)
{
    private PermanentContract()
        : this(default, default, default)
    {
    }
}

public abstract class EmploymentContract(
    EmploymentContractId id,
    EmployeeId employeeId,
    Employee employee
) : IEntity<EmploymentContractId, Guid>
{
    public EmploymentContractId Id { get; } = id;
    public EmployeeId EmployeeId { get; } = employeeId;
    public Employee Employee { get; } = employee;

    // public Duration Duration { get; init; }
    // public DateTime StartDate { get; init; }
    // public DateTime? EndDate { get; init; }
    // public decimal BaseSalary { get; init; }
    // public decimal? Bonus { get; init; }
    // public string Position { get; init; }
    // public string Department { get; init; }
    // public EmployeeId? SupervisorId { get; init; }
}