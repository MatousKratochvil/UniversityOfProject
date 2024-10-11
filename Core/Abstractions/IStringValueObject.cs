namespace Core.Abstractions;

public interface IStringValueObject : IValueObject
{
	string Value { get; }
}