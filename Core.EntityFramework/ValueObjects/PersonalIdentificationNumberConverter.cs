﻿using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class PersonalIdentificationNumberConverter() :
	ValueConverter<PersonalIdentificationNumber, string>(
		personIdentification => personIdentification.Value,
		@string => new PersonalIdentificationNumber(@string)
	);