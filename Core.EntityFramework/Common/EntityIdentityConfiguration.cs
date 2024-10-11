using Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.Common;

public sealed class EntityIdentityConverter<TIdentity, TKey>() :
	ValueConverter<TIdentity, TKey>(
		id => id.Id,
		guid => (TIdentity)Activator.CreateInstance(typeof(TIdentity), guid)!)
	where TIdentity : IEntityIdentity<TKey>;