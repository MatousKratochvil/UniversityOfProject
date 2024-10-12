using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class TypeConverter(params Type[] types) :
	ValueConverter<Type, string>(
		type => type.Name,
		name => types.First(type => type.Name == name),
		new ConverterMappingHints(size: types.Max(type => type.Name.Length), unicode: true)
	);