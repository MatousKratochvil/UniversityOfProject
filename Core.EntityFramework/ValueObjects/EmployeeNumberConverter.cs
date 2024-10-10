using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class EmployeeNumberConverter():
    ValueConverter<EmployeeNumber, string>(
        employeeNumber => employeeNumber.Value,
        @string => new EmployeeNumber(@string)
    );