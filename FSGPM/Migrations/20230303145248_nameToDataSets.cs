using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class nameToDataSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataSetName",
                table: "DataSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSetName",
                table: "DataSets");
        }
    }
}
