namespace Core.ValueObjects;

public struct InfiniteDate : IPastDate, IFutureDate
{
	public DateTime Value => DateTime.MaxValue;
}