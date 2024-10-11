using Core.ComplexObjects;
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
	Employee employee,
	DepartmentId departmentId,
	Department department,
	Period period)
	: EmploymentContract(id, employeeId, employee, departmentId, department, period)
{
	private TemporaryContract()
		: this(default, default, default, default, default, default)
	{
	}
}

public sealed class PermanentContract(
	EmploymentContractId id,
	EmployeeId employeeId,
	Employee employee,
	DepartmentId departmentId,
	Department department,
	Period period)
	: EmploymentContract(id, employeeId, employee, departmentId, department, period)
{
	private PermanentContract()
		: this(default, default, default, default, default, default)
	{
	}
}

public abstract class EmploymentContract(
	EmploymentContractId id,
	EmployeeId employeeId,
	Employee employee,
	DepartmentId departmentId,
	Department department,
	Period period)
	: IEntity<EmploymentContractId, Guid>
{ 
	public EmploymentContractId Id { get; } = id;
	public EmployeeId EmployeeId { get; } = employeeId;
	public Employee Employee { get; } = employee;
	public DepartmentId DepartmentId { get; } = departmentId;
	public Department Department { get; } = department;
	public Period Period { get; } = period;

	// public decimal BaseSalary { get; init; }
	// public decimal? Bonus { get; init; }
	// public string Position { get; init; }
	// public string Department { get; init; }
	// public EmployeeId? SupervisorId { get; init; }
}