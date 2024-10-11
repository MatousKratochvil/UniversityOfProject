using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeType = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Person_Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Person_Address_City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Address_State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Address_Street = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Address_ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Person_ContactInformation_Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_ContactInformation_PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Identification_BirthDate = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    Person_Identification_PersonalIdentificationNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Person_Name_FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Name_LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Person_Name_MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentContract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContractType = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentContract", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesSet");

            migrationBuilder.DropTable(
                name: "EmploymentContract");
        }
    }
}
