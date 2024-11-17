using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;

namespace Core.ValueObjects.Combined;

public record PersonalInformation(
	PersonName Name,
	BirthDate BirthDate,
	NationalIdentificationNumber? NationalIdentificationNumber,
	ContactInformation ContactInformation,
	MaritalStatus? MaritalStatus
)
{
	private PersonalInformation() : this(default, default, default, default, default)
	{
	}
}