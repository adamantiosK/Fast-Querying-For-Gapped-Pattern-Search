using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTableToStoreSuffixArrayResultsAndOverHead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OverHeadMsCalculated",
                table: "DataSets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "SACalculated",
                table: "DataSets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SuffixArraySets",
                columns: table => new
                {
                    SuffixArrayGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSetGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuffixIndex = table.Column<int>(type: "int", nullable: false),
                    SuffixLexicographicOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuffixArraySets", x => x.SuffixArrayGuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuffixArraySets");

            migrationBuilder.DropColumn(
                name: "OverHeadMsCalculated",
                table: "DataSets");

            migrationBuilder.DropColumn(
                name: "SACalculated",
                table: "DataSets");
        }
    }
}
