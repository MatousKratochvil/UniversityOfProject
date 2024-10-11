using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class FutureDateConverter() :
	ValueConverter<IFutureDate, int>(
		futureDate => Covert(futureDate),
		@int => Covert(@int)
	)
{
	private static int Covert(IFutureDate date) =>
		date switch
		{
			FutureDate futureDate => Converters.DateToInt(futureDate.Value),
			InvalidFutureDate => -1,
			InfiniteDate => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(date), date, null)
		};

	private static IFutureDate Covert(int i)
		=> i switch
		{
			0 => new InfiniteDate(),
			-1 => new InvalidFutureDate(DateTime.MinValue),
			_ => GetFutureDate(i)
		};

	private static IFutureDate GetFutureDate(int i)
	{
		var date = Converters.DateFromInt(i);

		return date.CompareTo(DateTime.Now) switch
		{
			< 0 => new InvalidFutureDate(date),
			_ => new FutureDate(date)
		};
	}
}