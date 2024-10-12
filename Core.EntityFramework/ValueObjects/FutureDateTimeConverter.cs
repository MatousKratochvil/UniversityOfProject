using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public class FutureDateTimeConverter() :
	ValueConverter<IFutureDate, long>(
		futureDate => Covert(futureDate),
		@long => Covert(@long)
	)
{
	private static long Covert(IFutureDate date) =>
		date switch
		{
			FutureDate futureDate => Converters.DateTimeToLong(futureDate.Value),
			InvalidFutureDate => -1,
			InfiniteDate => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(date), date, null)
		};

	private static IFutureDate Covert(long dateNumber)
		=> dateNumber switch
		{
			0 => new InfiniteDate(),
			-1 => new InvalidFutureDate(DateTime.MinValue),
			_ => GetFutureDate(dateNumber)
		};

	private static IFutureDate GetFutureDate(long dateNumber)
	{
		var date = Converters.DateTimeFromLong(dateNumber);

		return date.CompareTo(DateTime.Now) switch
		{
			< 0 => new InvalidFutureDate(date),
			_ => new FutureDate(date)
		};
	}
}