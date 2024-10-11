using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class BirthDateConverter() :
    ValueConverter<BirthDate, int>(
        birthDate => DateToInt(birthDate.Value),
        @int => new BirthDate(DateFromInt(@int))
    )
{
    private static DateTime DateFromInt(int i)
    {
        var year = i / 1_00_00;
        var month = (i - year * 1_00_00) / 1_00;
        var day = i - year * 1_00_00 - month * 1_00;
        return new DateTime(year, month, day);
    }

    private static int DateToInt(DateTime birthDateValue) =>
        birthDateValue.Year * 1_00_00 + birthDateValue.Month * 1_00 + birthDateValue.Day;
}