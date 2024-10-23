using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriemChecker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HouOokTicksBij : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TicksOmTeBerekenen",
                table: "PriemCheckResultaten",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicksOmTeBerekenen",
                table: "PriemCheckResultaten");
        }
    }
}
