using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddressMovedToContactInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_Address_ZipCode",
                table: "EmployeesSet",
                newName: "Person_ContactInformation_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Person_Address_Street",
                table: "EmployeesSet",
                newName: "Person_ContactInformation_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Person_Address_State",
                table: "EmployeesSet",
                newName: "Person_ContactInformation_Address_State");

            migrationBuilder.RenameColumn(
                name: "Person_Address_City",
                table: "EmployeesSet",
                newName: "Person_ContactInformation_Address_City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_ContactInformation_Address_ZipCode",
                table: "EmployeesSet",
                newName: "Person_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Person_ContactInformation_Address_Street",
                table: "EmployeesSet",
                newName: "Person_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Person_ContactInformation_Address_State",
                table: "EmployeesSet",
                newName: "Person_Address_State");

            migrationBuilder.RenameColumn(
                name: "Person_ContactInformation_Address_City",
                table: "EmployeesSet",
                newName: "Person_Address_City");
        }
    }
}
