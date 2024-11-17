using Core.EntityFramework.Common;
using Core.ValueObjects.Combined;
using Core.ValueObjects.Simple;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.ValueObjects;

public class PersonalInformationConfiguration : IComplexPropertyConfiguration<PersonalInformation>
{
	public ComplexPropertyBuilder<PersonalInformation> Configure(ComplexPropertyBuilder<PersonalInformation> builder)
	{
		builder.Property(x => x.BirthDate)
			.HasColumnName("BirthDate")
			.HasConversion<DateValueObjectConverter<BirthDate>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.NationalIdentificationNumber)
			.HasColumnName("NationalIdentificationNumber")
			.HasConversion<StringValueObjectConverter<NationalIdentificationNumber>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.MaritalStatus)
			.HasColumnName("MaritalStatus")
			.HasConversion<MaritalStatusConverter>()
			.IsRequired();

		builder.ComplexProperty(x => x.Name).Configure(new PersonNameConfiguration());
		builder.ComplexProperty(x => x.ContactInformation).Configure(new ContactInformationConfiguration());

		return builder;
	}
}