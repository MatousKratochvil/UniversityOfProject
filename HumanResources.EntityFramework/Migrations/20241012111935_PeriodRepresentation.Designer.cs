﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HumanResources.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumanResources.EntityFramework.Migrations
{
    [DbContext(typeof(HumanResourcesContext))]
    [Migration("20241012111935_PeriodRepresentation")]
    partial class PeriodRepresentation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("HumanResources.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HumanResources.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.ComplexProperty<Dictionary<string, object>>("Person", "HumanResources.Entities.Employee.Person#Person", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Title")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.ComplexProperty<Dictionary<string, object>>("Address", "HumanResources.Entities.Employee.Person#Person.Address#Address", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("State")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("ZipCode")
                                        .IsRequired()
                                        .HasMaxLength(10)
                                        .HasColumnType("TEXT");
                                });

                            b1.ComplexProperty<Dictionary<string, object>>("ContactInformation", "HumanResources.Entities.Employee.Person#Person.ContactInformation#ContactInformation", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("Email")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("PhoneNumber")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");
                                });

                            b1.ComplexProperty<Dictionary<string, object>>("Identification", "HumanResources.Entities.Employee.Person#Person.Identification#PersonIdentification", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<int>("BirthDate")
                                        .HasMaxLength(10)
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("PersonalIdentificationNumber")
                                        .IsRequired()
                                        .HasMaxLength(20)
                                        .HasColumnType("TEXT");
                                });

                            b1.ComplexProperty<Dictionary<string, object>>("Name", "HumanResources.Entities.Employee.Person#Person.Name#PersonName", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("FirstName")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("LastName")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("MiddleName")
                                        .HasMaxLength(50)
                                        .HasColumnType("TEXT");
                                });
                        });

                    b.HasKey("Id");

                    b.ToTable("EmployeesSet");

                    b.HasDiscriminator<string>("EmployeeType").HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HumanResources.Entities.EmploymentContract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContractType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.ComplexProperty<Dictionary<string, object>>("PeriodRepresentation", "HumanResources.Entities.EmploymentContract.PeriodRepresentation#PeriodRepresentation", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Discriminator")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("End")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Start")
                                .HasColumnType("INTEGER");
                        });

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmploymentContract");

                    b.HasDiscriminator<string>("ContractType").HasValue("EmploymentContract");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HumanResources.Entities.AdministrativeEmployee", b =>
                {
                    b.HasBaseType("HumanResources.Entities.Employee");

                    b.HasDiscriminator().HasValue("Administrative");
                });

            modelBuilder.Entity("HumanResources.Entities.Professor", b =>
                {
                    b.HasBaseType("HumanResources.Entities.Employee");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("HumanResources.Entities.RegularEmployee", b =>
                {
                    b.HasBaseType("HumanResources.Entities.Employee");

                    b.HasDiscriminator().HasValue("Regular");
                });

            modelBuilder.Entity("HumanResources.Entities.PermanentContract", b =>
                {
                    b.HasBaseType("HumanResources.Entities.EmploymentContract");

                    b.HasDiscriminator().HasValue("Permanent");
                });

            modelBuilder.Entity("HumanResources.Entities.TemporaryContract", b =>
                {
                    b.HasBaseType("HumanResources.Entities.EmploymentContract");

                    b.HasDiscriminator().HasValue("Temporary");
                });

            modelBuilder.Entity("HumanResources.Entities.EmploymentContract", b =>
                {
                    b.HasOne("HumanResources.Entities.Department", "Department")
                        .WithOne()
                        .HasForeignKey("HumanResources.Entities.EmploymentContract", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResources.Entities.Employee", "Employee")
                        .WithOne("Contract")
                        .HasForeignKey("HumanResources.Entities.EmploymentContract", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HumanResources.Entities.Employee", b =>
                {
                    b.Navigation("Contract")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
