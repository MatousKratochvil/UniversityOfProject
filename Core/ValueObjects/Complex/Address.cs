using Core.ValueObjects.Simple;

namespace Core.ValueObjects.Complex;

public record Address(
	Street Street,
	City City,
	State State,
	ZipCode ZipCode
);