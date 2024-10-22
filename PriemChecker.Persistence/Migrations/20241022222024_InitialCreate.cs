using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriemChecker.Persistence.Migrations
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
                    PriemKandidaatWaarde = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsPriemgetal = table.Column<bool>(type: "bit", nullable: false),
                    AantalLoops = table.Column<double>(type: "float", nullable: true),
                    MilliSecondenOmTeBerekenen = table.Column<double>(type: "float", nullable: true),
                    UitgerekendOp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriemCheckResultaten", x => x.PriemKandidaatWaarde);
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
