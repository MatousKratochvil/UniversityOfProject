using Core.ValueObjects.Combined;
using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;

namespace CoreTests;

public class PersonalInformationTest
{
	[Fact]
	public void ShouldCreatePersonalInformation()
	{
		var personalInformation = new PersonalInformation(
			new PersonName(
				FirstName.Create("John"),
				MiddleName.Create("Doe"),
				LastName.Create("Smith")
			),
			BirthDate.Create(new DateOnly(1980, 1, 1)),
			NationalIdentificationNumber.Create("123-45-6789"),
			new ContactInformation(
				new Address(
					Street.Create("123 Main St"),
					City.Create("Springfield"),
					State.Create("IL"),
					ZipCode.Create("62701")
				),
				EmailAddress.Create("john@doe.com"),
				PhoneNumber.Create("5555555555")
			),
			new MaritalStatus.Single()
		);

		Assert.NotNull(personalInformation);
	}
}