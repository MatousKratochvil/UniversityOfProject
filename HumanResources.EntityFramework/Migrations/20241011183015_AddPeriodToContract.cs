using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResources.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodToContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period_End",
                table: "EmploymentContract",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period_Start",
                table: "EmploymentContract",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period_End",
                table: "EmploymentContract");

            migrationBuilder.DropColumn(
                name: "Period_Start",
                table: "EmploymentContract");
        }
    }
}
