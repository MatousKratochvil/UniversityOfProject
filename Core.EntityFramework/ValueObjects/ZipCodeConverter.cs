using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class ZipCodeConverter() :
	ValueConverter<ZipCode, string>(
		zipCode => zipCode.Value,
		@string => new ZipCode(@string)
	);