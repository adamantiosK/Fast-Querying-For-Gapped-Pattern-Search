using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class updaetstorageformatforsuffixarrays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuffixIndex",
                table: "SuffixArraySets");

            migrationBuilder.DropColumn(
                name: "SuffixLexicographicOrder",
                table: "SuffixArraySets");

            migrationBuilder.AddColumn<string>(
                name: "SuffixArray",
                table: "SuffixArraySets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuffixArray",
                table: "SuffixArraySets");

            migrationBuilder.AddColumn<int>(
                name: "SuffixIndex",
                table: "SuffixArraySets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuffixLexicographicOrder",
                table: "SuffixArraySets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
