using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToSavedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatternLenght",
                table: "Patterns");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Constraints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Constraints");

            migrationBuilder.AddColumn<int>(
                name: "PatternLenght",
                table: "Patterns",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
