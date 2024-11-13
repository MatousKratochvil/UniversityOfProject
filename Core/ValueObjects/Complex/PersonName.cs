using Core.ValueObjects.Simple;

namespace Core.ValueObjects.Complex;

public record PersonName(
	FirstName FirstName,
	MiddleName? MiddleName,
	LastName LastName
);