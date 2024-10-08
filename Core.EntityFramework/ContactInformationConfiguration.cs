﻿using Core.EntityFramework.Common;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class ContactInformationConfiguration : IComplexPropertyConfiguration<ContactInformation>
{
    public ComplexPropertyBuilder<ContactInformation> Configure(ComplexPropertyBuilder<ContactInformation> builder)
    {
        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired();

        return builder;
    }
}