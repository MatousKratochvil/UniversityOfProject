using Core.Persistence.Abstractions;
using Core.ValueObjects;

namespace HumanResources.Entities;

public record struct DepartmentId(Guid Id) : IEntityIdentity<Guid>
{
	public DepartmentId(string id)
		: this(Guid.Parse(id))
	{
	}

	public static implicit operator Guid(DepartmentId id) => id.Id;
	public static DepartmentId Empty => new(Guid.Empty);
}

public sealed class Department : IEntity<DepartmentId, Guid>
{
	public DepartmentId Id { get; init; } = DepartmentId.Empty;
	public SingleName Name { get; init; } = new("DepartmentName");
}