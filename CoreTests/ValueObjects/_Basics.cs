using System.Text.RegularExpressions;
using Core;

namespace CoreTests.ValueObjects;

public static class Validation
{
    public static void EmptyValidation(string value, string? propertyname)
    {
        // Do nothing
    }

    public static void NotNullValidator(string input, string? propertyName = null)
        => Guard.ThrowWhenNullOrWhiteSpace(input, propertyName);

    public static void MinLengthValidator(string input, int min, string? propertyName = null)
        => Guard.ThrowWhenSmallerLength(input, min, propertyName);

    public static void MinLengthThreeValidator(string input, string? propertyName = null)
        => MinLengthValidator(input, 3, propertyName);

    public static void RegexValidator(Regex regex, string input, string? propertyName = null)
        => Guard.ThrowWhenRegexNotMatch(input, regex, propertyName);
}