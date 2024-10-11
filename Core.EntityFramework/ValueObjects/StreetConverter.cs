using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StreetConverter() :
	ValueConverter<Street, string>(
		street => street.Value,
		@string => new Street(@string)
	);