using System.Globalization;
using Core.Abstractions;
using Core.ComplexObjects;
using Core.ValueObjects;

namespace HumanResources.Formatters;

public class PeriodCombinedFormatter : IFormatter<Period>
{
	public static PeriodCombinedFormatter Instance { get; } = new();

	public string Format(Period obj)
		=> $"{GetStart(obj.Start)} - {GetEnd(obj.End)}";

	private string GetEnd(IFutureDate objEnd)
		=> objEnd switch
		{
			FutureDate end => end.Value.ToString("d.M.yyyy", CultureInfo.CurrentCulture),
			InvalidFutureDate end => "Invalid date",
			_ => throw new NotSupportedException()
		};

	private string GetStart(IPastDate objStart)
		=> objStart switch
		{
			PastDate start => start.Value.ToString("d.M.yyyy", CultureInfo.CurrentCulture),
			InvalidPastDate start => "Invalid date",
			_ => throw new NotSupportedException()
		};
}