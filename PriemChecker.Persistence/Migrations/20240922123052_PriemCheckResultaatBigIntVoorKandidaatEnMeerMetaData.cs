using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriemChecker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PriemCheckResultaatBigIntVoorKandidaatEnMeerMetaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Stap 1: Voeg een nieuwe tijdelijke kolom toe
            migrationBuilder.AddColumn<double>(
                name: "NewId",
                table: "PriemCheckResultaten",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            // Stap 2: Kopieer de waarden van de originele Id kolom naar de nieuwe kolom
            migrationBuilder.Sql("UPDATE PriemCheckResultaten SET NewId = Id");

            // Stap 3: Verwijder de originele Id kolom
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PriemCheckResultaten");

            // Stap 4: Hernoem de nieuwe kolom naar Id
            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "PriemCheckResultaten",
                newName: "Id");

            // Wijzig het type van PriemKandidaatWaarde naar nvarchar(max)
            migrationBuilder.AlterColumn<string>(
                name: "PriemKandidaatWaarde",
                table: "PriemCheckResultaten",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Voeg de overige kolommen toe
            migrationBuilder.AddColumn<double>(
                name: "AantalLoops",
                table: "PriemCheckResultaten",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MilliSecondenOmTeBerekenen",
                table: "PriemCheckResultaten",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UitgerekendOp",
                table: "PriemCheckResultaten",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Verwijder de nieuw toegevoegde kolommen
            migrationBuilder.DropColumn(
                name: "AantalLoops",
                table: "PriemCheckResultaten");

            migrationBuilder.DropColumn(
                name: "MilliSecondenOmTeBerekenen",
                table: "PriemCheckResultaten");

            migrationBuilder.DropColumn(
                name: "UitgerekendOp",
                table: "PriemCheckResultaten");

            // Voeg de oorspronkelijke Id kolom weer toe
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PriemCheckResultaten",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Kopieer de waarden van de nieuwe kolom terug naar de originele kolom (optioneel als je een down migratie nodig hebt)
            migrationBuilder.Sql("UPDATE PriemCheckResultaten SET Id = CAST(NewId AS int)");

            // Verwijder de tijdelijke kolom
            migrationBuilder.DropColumn(
                name: "NewId",
                table: "PriemCheckResultaten");

            // Wijzig PriemKandidaatWaarde terug naar int
            migrationBuilder.AlterColumn<int>(
                name: "PriemKandidaatWaarde",
                table: "PriemCheckResultaten",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
