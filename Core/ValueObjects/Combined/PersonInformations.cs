using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;
using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Combined;

public record PersonalInformation(
	PersonName Name,
	BirthDate BirthDate,
	PersonalIdentificationNumber? PersonalIdentificationNumber,
	ContactInformation ContactInformation,
	IMaritalStatus? MaritalStatus
);


