using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class SingleNameConverter(SingleNameValidator validator) :
    ValueConverter<SingleName, string>(
        singleName => singleName.Value,
        value => new SingleName(value, validator, null)
    );