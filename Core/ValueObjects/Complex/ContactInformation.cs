using Core.ValueObjects.Simple;

namespace Core.ValueObjects.Complex;

public record ContactInformation(
	Address HomeAddress,
	EmailAddress EmailAddress,
	PhoneNumber PhoneNumber
)
{
	private ContactInformation() : this(default, default, default)
	{
	}
}