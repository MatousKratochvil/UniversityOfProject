﻿using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class PastDateConverter() :
	ValueConverter<IPastDate, int>(
		pastDate => Covert(pastDate),
		@int => Covert(@int)
	)
{
	private static int Covert(IPastDate date) =>
		date switch
		{
			PastDate futureDate => Converters.DateToInt(futureDate.Value),
			InvalidPastDate => -1,
			InfiniteDate => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(date), date, null)
		};

	private static IPastDate Covert(int dateNumber)
		=> dateNumber switch
		{
			0 => new InfiniteDate(),
			-1 => new InvalidPastDate(DateTime.MinValue),
			_ => GetFutureDate(dateNumber)
		};

	private static IPastDate GetFutureDate(int dateNumber)
	{
		var date = Converters.DateFromInt(dateNumber);

		return date.CompareTo(DateTime.Now) switch
		{
			> 0 => new InvalidPastDate(date),
			_ => new PastDate(date)
		};
	}
}