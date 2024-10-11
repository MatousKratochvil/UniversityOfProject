using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record Person(
	Title? Title,
	PersonName Name,
	PersonIdentification Identification,
	Address Address,
	ContactInformation ContactInformation
) : IComplexObject
{
	private Person() : this(default!, default!, default!, default!, default!)
	{
	}
}