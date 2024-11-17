using System.Reflection;
using Core.ValueObjects.Simple.Abstract;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StringValueObjectConverter<T>() :
	ValueConverter<T, string>(
		vo => vo.Value,
		@string => (T)typeof(T)
			.GetMethod("Create", BindingFlags.NonPublic | BindingFlags.Static)
			.Invoke(null, new object[] { @string })
	) where T : IStringValueObject;

