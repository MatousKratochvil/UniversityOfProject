using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PeriodRepresentation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Period_Start",
                table: "EmploymentContract",
                newName: "PeriodRepresentation_Start");

            migrationBuilder.RenameColumn(
                name: "Period_End",
                table: "EmploymentContract",
                newName: "PeriodRepresentation_End");

            migrationBuilder.AddColumn<string>(
                name: "PeriodRepresentation_Discriminator",
                table: "EmploymentContract",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodRepresentation_Discriminator",
                table: "EmploymentContract");

            migrationBuilder.RenameColumn(
                name: "PeriodRepresentation_Start",
                table: "EmploymentContract",
                newName: "Period_Start");

            migrationBuilder.RenameColumn(
                name: "PeriodRepresentation_End",
                table: "EmploymentContract",
                newName: "Period_End");
        }
    }
}
