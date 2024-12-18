﻿using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class EmailConverter() :
	ValueConverter<Email, string>(
		email => email.Value,
		@string => new Email(@string)
	);