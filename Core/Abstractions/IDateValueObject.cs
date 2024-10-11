namespace Core.Abstractions;

public interface IDateValueObject : IValueObject
{
    DateTime Value { get; }
}