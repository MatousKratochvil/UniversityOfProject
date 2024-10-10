using System.Globalization;

namespace Core.Abstractions;

public interface IUserContext
{
    CultureInfo Culture { get; }
}