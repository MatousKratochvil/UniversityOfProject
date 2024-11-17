using System.Reflection;
using Core.ValueObjects.Simple.Abstract;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class DateValueObjectConverter<T>() :
	ValueConverter<T, int>(
		vo => DateConvertor.Convert(vo.Value),
		@int => (T)typeof(T)
			.GetMethod("Create", BindingFlags.NonPublic | BindingFlags.Static)
			.Invoke(null, new object[] { DateConvertor.Convert(@int) })
	) where T : IDateValueObject;

public static class DateConvertor
{
	public static int Convert(DateOnly date) => date.Year * 10000 + date.Month * 100 + date.Day;
	public static DateOnly Convert(int date) => new(date / 10000, date / 100 % 100, date % 100);
}