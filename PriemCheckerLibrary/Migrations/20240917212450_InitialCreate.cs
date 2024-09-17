using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriemCheckerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriemCheckResultaten",
                columns: table => new
                {
                    priemKandidaatWaarde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isPriemgetal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriemCheckResultaten", x => x.priemKandidaatWaarde);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriemCheckResultaten");
        }
    }
}
