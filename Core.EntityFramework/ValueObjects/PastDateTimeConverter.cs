using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class PastDateTimeConverter() :
	ValueConverter<IPastDate, long>(
		pastDate => Covert(pastDate),
		@long => Covert(@long)
	)
{
	private static long Covert(IPastDate date) =>
		date switch
		{
			PastDate futureDate => Converters.DateTimeToLong(futureDate.Value),
			InvalidPastDate => -1,
			InfiniteDate => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(date), date, null)
		};

	private static IPastDate Covert(long dateNumber)
		=> dateNumber switch
		{
			0 => new InfiniteDate(),
			-1 => new InvalidPastDate(DateTime.MinValue),
			_ => GetFutureDate(dateNumber)
		};

	private static IPastDate GetFutureDate(long dateNumber)
	{
		var date = Converters.DateTimeFromLong(dateNumber);

		return date.CompareTo(DateTime.Now) switch
		{
			> 0 => new InvalidPastDate(date),
			_ => new PastDate(date)
		};
	}
}