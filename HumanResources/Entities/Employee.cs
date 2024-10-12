using Core.ComplexObjects;
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

public sealed class RegularEmployee : Employee
{
	public RegularEmployee(EmployeeId id, Person person, EmploymentContract contract)
		: base(id, person, contract)
	{
	}

	private RegularEmployee(RegularEmployee contract)
		: base(contract)
	{
	}

	internal override Employee CopyEmployee() => new RegularEmployee(this);

	private RegularEmployee()
	{
	}
}

public sealed class AdministrativeEmployee : Employee
{
	public AdministrativeEmployee(EmployeeId id, Person person, EmploymentContract contract)
		: base(id, person, contract)
	{
	}

	private AdministrativeEmployee(AdministrativeEmployee contract)
		: base(contract)
	{
	}

	internal override Employee CopyEmployee() => new AdministrativeEmployee(this);

	private AdministrativeEmployee()
	{
	}
}

public sealed class Professor
	: Employee
{
	public Professor(EmployeeId id, Person person, EmploymentContract contract)
		: base(id, person, contract)
	{
	}

	private Professor(Professor contract)
		: base(contract)
	{
	}

	internal override Employee CopyEmployee() => new Professor(this);

	private Professor()
	{
	}
}

public abstract class Employee : IEntity<EmployeeId, Guid>
{
	protected Employee()
	{
	}

	protected Employee(EmployeeId id, Person person, EmploymentContract contract)
	{
		Id = id;
		Person = person;
		Contract = contract;
	}

	protected Employee(Employee contract)
	{
		Id = contract.Id;
		Person = contract.Person;
		Contract = contract.Contract;
	}

	internal abstract Employee CopyEmployee();

	public EmployeeId Id { get; set; }
	public Person Person { get; set; } = null!;
	public EmploymentContract Contract { get; set; } = null!;
}

public static class EmployeeExtensions
{
	public static T WithContract<T>(this T employee, EmploymentContract employmentContract)
		where T : Employee
	{
		var copy = employee.CopyEmployee();
		copy.Contract = employmentContract;
		return (T)copy;
	}
}