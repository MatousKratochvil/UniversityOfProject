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
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

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
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContractType = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Period_End = table.Column<int>(type: "INTEGER", nullable: false),
                    Period_Start = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentContract_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentContract_EmployeesSet_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentContract_DepartmentId",
                table: "EmploymentContract",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentContract_EmployeeId",
                table: "EmploymentContract",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentContract");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeesSet");
        }
    }
}
