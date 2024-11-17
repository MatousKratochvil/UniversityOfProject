using Core.ValueObjects.Combined;

namespace HumanResources.Models;

public class Employee : GuidEntity
{
	public PersonalInformation PersonalInformation { get; set; }
}

public abstract class GuidEntity
{
	public Guid Id { get; protected set; }
	public DateTime CreatedAt { get; protected set; }
	public DateTime? UpdatedAt { get; protected set; }
	public DateTime? DeletedAt { get; protected set; }
}