using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class CreatingAppropriateClassesForStoringReportStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstraintCounts",
                columns: table => new
                {
                    ConstraintCountGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstraintMin = table.Column<int>(type: "int", nullable: false),
                    ConstraintMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstraintCounts", x => x.ConstraintCountGuid);
                });

            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    ConstraintGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSetGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstraintCountGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.ConstraintGuid);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    DataSetGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.DataSetGuid);
                });

            migrationBuilder.CreateTable(
                name: "Patterns",
                columns: table => new
                {
                    PatternGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSetGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatternText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatternLenght = table.Column<int>(type: "int", nullable: false),
                    DefaultPatternLength = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patterns", x => x.PatternGuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstraintCounts");

            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropTable(
                name: "Patterns");
        }
    }
}
