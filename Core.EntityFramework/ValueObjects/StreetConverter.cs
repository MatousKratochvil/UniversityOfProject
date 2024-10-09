using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StreetConverter(StreetValidator validator) :
    ValueConverter<Street, string>(
        street => street.Value,
        value => new Street(value, validator, null)
    );