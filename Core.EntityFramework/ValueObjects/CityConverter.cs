using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class CityConverter() :
	ValueConverter<City, string>(
		city => city.Value,
		@string => new City(@string)
	);