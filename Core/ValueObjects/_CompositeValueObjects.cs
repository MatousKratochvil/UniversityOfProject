namespace Core.ValueObjects;

public sealed record ContactInformation(Email Email, PhoneNumber PhoneNumber);
public sealed record Address(Street Street, City City, State State, ZipCode ZipCode);
public sealed record PersonName(SingleName FirstSingleName, SingleName? MiddleName, SingleName LastSingleName);
public sealed record PersonIdentification(BirthDate BirthDate, PersonalIdentificationNumber PersonalIdentificationNumber);