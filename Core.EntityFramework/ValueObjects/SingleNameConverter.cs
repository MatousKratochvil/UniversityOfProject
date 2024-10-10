using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class SingleNameConverter() :
    ValueConverter<SingleName, string>(
        singleName => singleName.Value,
        @string => new SingleName(@string)
    );