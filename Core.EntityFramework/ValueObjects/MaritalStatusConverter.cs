using Core.ValueObjects.Simple;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class MaritalStatusConverter() :
	ValueConverter<MaritalStatus, string>(
		status => MaritalStatus.ToRepresentation(status),
		@string => MaritalStatus.FromRepresentation(@string)
	);