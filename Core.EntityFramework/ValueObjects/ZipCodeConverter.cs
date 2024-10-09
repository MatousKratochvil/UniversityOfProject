using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class ZipCodeConverter(ZipCodeValidator validator) :
    ValueConverter<ZipCode, string>(
        street => street.Value,
        value => new ZipCode(value, validator, CoreRegex.Empty(), null)
    );