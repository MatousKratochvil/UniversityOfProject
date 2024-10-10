using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class PhoneNumberConverter():
    ValueConverter<PhoneNumber, string>(
        phoneNumber => phoneNumber.Value,
        @string => new PhoneNumber(@string)
    );

