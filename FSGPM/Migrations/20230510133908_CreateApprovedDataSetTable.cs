using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class CreateApprovedDataSetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlgoDataSetResultsApproved",
                columns: table => new
                {
                    AlgoResultGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DS_Result_Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlgorithmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    K_Selection = table.Column<int>(type: "int", nullable: false),
                    DataSetGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConstraintCountGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatternLength = table.Column<int>(type: "int", nullable: false),
                    Miliseconds = table.Column<long>(type: "bigint", nullable: false),
                    Miliseconds_Preproccesing = table.Column<long>(type: "bigint", nullable: false),
                    Miliseconds_AverageRun = table.Column<long>(type: "bigint", nullable: false),
                    PatternsFound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgoDataSetResultsApproved", x => x.AlgoResultGuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgoDataSetResultsApproved");
        }
    }
}
