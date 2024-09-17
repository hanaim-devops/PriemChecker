using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriemCheckerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class IdVeldInPriemCheckResultaat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPriemgetal",
                table: "PriemCheckResultaten",
                newName: "IsPriemgetal");

            migrationBuilder.RenameColumn(
                name: "priemKandidaatWaarde",
                table: "PriemCheckResultaten",
                newName: "PriemKandidaatWaarde");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PriemCheckResultaten",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PriemCheckResultaten");

            migrationBuilder.RenameColumn(
                name: "IsPriemgetal",
                table: "PriemCheckResultaten",
                newName: "isPriemgetal");

            migrationBuilder.RenameColumn(
                name: "PriemKandidaatWaarde",
                table: "PriemCheckResultaten",
                newName: "priemKandidaatWaarde");
        }
    }
}
