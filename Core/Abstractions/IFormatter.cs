namespace Core.Abstractions;

public interface IFormatter<in T>
{
    string Format(T obj);
}