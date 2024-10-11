using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record PersonIdentification(
	BirthDate BirthDate,
	PersonalIdentificationNumber PersonalIdentificationNumber) : IComplexObject;