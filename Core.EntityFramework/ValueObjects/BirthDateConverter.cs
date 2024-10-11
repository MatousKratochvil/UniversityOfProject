using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class BirthDateConverter() :
	ValueConverter<BirthDate, int>(
		birthDate => Converters.DateToInt(birthDate.Value),
		@int => new BirthDate(Converters.DateFromInt(@int))
	);