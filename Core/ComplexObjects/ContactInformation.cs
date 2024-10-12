using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record ContactInformation(Address Address, Email Email, PhoneNumber PhoneNumber)
	: IComplexObject
{
	private ContactInformation() : this(default!, default!, default!)
	{
	}
}