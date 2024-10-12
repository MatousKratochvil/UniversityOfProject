namespace Core.EntityFramework.ValueObjects;

internal class Converters
{
	public static DateTime DateFromInt(int i)
	{
		var year = i / 1_00_00;
		var month = (i - year * 1_00_00) / 1_00;
		var day = i - year * 1_00_00 - month * 1_00;
		return new DateTime(year, month, day);
	}

	public static int DateToInt(DateTime dateValue) =>
		dateValue.Year * 1_00_00
		+ dateValue.Month * 1_00
		+ dateValue.Day;

	public static DateTime DateTimeFromLong(long i)
	{
		var year = i / 1_00_00_00_00;
		var month = (i - year * 1_00_00_00_00) / 1_00_00_00;
		var day = (i - year * 1_00_00_00_00 - month * 1_00_00_00) / 1_00_00;
		var hour = (i - year * 1_00_00_00_00 - month * 1_00_00_00 - day * 1_00_00) / 1_00;
		var minute = (i - year * 1_00_00_00_00 - month * 1_00_00_00 - day * 1_00_00 - hour * 1_00) / 1;
		var second = i - year * 1_00_00_00_00 - month * 1_00_00_00 - day * 1_00_00 - hour * 1_00 - minute;
		return new DateTime((int)year, (int)month, (int)day, (int)hour, (int)minute, (int)second);
	}

	public static long DateTimeToLong(DateTime dateValue) =>
		dateValue.Year * 1_00_00_00_00
		+ dateValue.Month * 1_00_00_00
		+ dateValue.Day * 1_00_00
		+ dateValue.Hour * 1_00
		+ dateValue.Minute * 1
		+ dateValue.Second;
}