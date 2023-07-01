using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSGPM.Migrations
{
    /// <inheritdoc />
    public partial class SeperateRunningtimefrompreproccessingandinclcudeanaveragerunbasedonpatternCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Miliseconds_AverageRun",
                table: "AlgoDataSetResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Miliseconds_Preproccesing",
                table: "AlgoDataSetResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miliseconds_AverageRun",
                table: "AlgoDataSetResults");

            migrationBuilder.DropColumn(
                name: "Miliseconds_Preproccesing",
                table: "AlgoDataSetResults");
        }
    }
}
