﻿using Core;

namespace CoreTests;


public class PersonNameTests
{
    [Theory]
    [InlineData("John", null, "Doe")]
    [InlineData("John", "M", "Doe")]
    [InlineData("John", "Middle", "Doe")]
    public void Create_WithValidArguments_ReturnsPersonNameType(string firstName, string? middleName, string lastName)
    {
        var personName = PersonName.CreateBasic(firstName, middleName, lastName);

        Assert.Equal(firstName, personName.FirstSingleName);
        Assert.Equal(middleName, personName.MiddleName);
        Assert.Equal(lastName, personName.LastSingleName);
    }
    
    [Theory]
    [InlineData(null, null, "Doe")]
    [InlineData("John", null, null)]
    [InlineData(null, null, null)]
    [InlineData("J", null, "Doe")]
    [InlineData("J", "M", "Doe")]
    [InlineData("J", "M", "D")]
    [InlineData("John", "M", "D")]
    [InlineData("John", "", "Doe")]
    [InlineData("John", "M", "Alexandr Nikolajevič Petrovič Dostojenský Ivanovič Jan")]
    [InlineData("John", "Kristýna Marie Anna Terezie Johana Barbora Novotná Jan", "Doe")]
    [InlineData("František Josef Václav Karel Jan Nepomuk Alois Habsburg", "M", "Doe")]
    public void Create_WithInvalidArguments_ThrowsArgumentException(string firstName, string? middleName, string lastName)
    {
        Assert.Throws<ArgumentException>(() => PersonName.CreateBasic(firstName, middleName, lastName));
    }
}