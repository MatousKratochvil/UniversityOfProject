using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class TitleConverter() :
	ValueConverter<Title, string>(
		title => title.Value,
		@string => new Title(@string)
	);