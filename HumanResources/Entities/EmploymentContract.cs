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

public sealed class TemporaryContract : EmploymentContract
{
	public TemporaryContract(EmploymentContractId id, Period period)
		: base(id, period, null, null)
	{
	}

	public TemporaryContract(EmploymentContractId id, Period period, Employee employee, Department department)
		: base(id, period, employee, department)
	{
	}

	public TemporaryContract(TemporaryContract contract)
		: base(contract)
	{
	}

	internal override EmploymentContract CopyContract() => new TemporaryContract(this);

	private TemporaryContract()
	{
	}
}

public sealed class PermanentContract : EmploymentContract
{
	public PermanentContract(EmploymentContractId id, Period period, Employee employee, Department department)
		: base(id, period, employee, department)
	{
	}

	public PermanentContract(PermanentContract contract)
		: base(contract)
	{
	}

	internal override EmploymentContract CopyContract() => new PermanentContract(this);

	private PermanentContract()
	{
	}
}

public abstract class EmploymentContract : IEntity<EmploymentContractId, Guid>
{
	protected EmploymentContract()
	{
	}

	protected EmploymentContract(EmploymentContractId id, Period period, Employee employee, Department department)
	{
		Id = id;
		Period = period;
		Employee = employee;
		Department = department;
	}

	protected EmploymentContract(EmploymentContract contract)
	{
		Id = contract.Id;
		Employee = contract.Employee;
		Department = contract.Department;
		Period = contract.Period;
	}

	internal abstract EmploymentContract CopyContract();

	public EmploymentContractId Id { get; set; }
	public EmployeeId EmployeeId { get; set; }
	public Employee Employee { get; set; } = null!;
	public DepartmentId DepartmentId { get; set; }
	public Department Department { get; set; } = null!;
	public Period Period { get; set; } = null!;

	// public decimal BaseSalary { get; init; }
	// public decimal? Bonus { get; init; }
	// public string Position { get; init; }
	// public string Department { get; init; }
	// public EmployeeId? SupervisorId { get; init; }
}

public static class EmploymentContractExtensions
{
	public static T WithEmployee<T>(this T contract, Employee employee)
		where T : EmploymentContract
	{
		var copy = contract.CopyContract();
		copy.Employee = employee;
		return (T)copy;
	}

	public static T WithDepartment<T>(this T contract, Department department)
		where T : EmploymentContract
	{
		var copy = contract.CopyContract();
		copy.Department = department;
		return (T)copy;
	}
}