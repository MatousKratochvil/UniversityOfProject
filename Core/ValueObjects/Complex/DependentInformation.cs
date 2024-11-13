using Core.ValueObjects.Simple;
using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Complex;

public record DependentInformation(
	FirstName FirstName,
	LastName LastName,
	BirthDate BirthDate,
	IPersonRelationship Relationship
);