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
            migrationBuilder.AlterColumn<string>(
                name: "PriemKandidaatWaarde",
                table: "PriemCheckResultaten",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Id",
                table: "PriemCheckResultaten",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
            migrationBuilder.DropColumn(
                name: "AantalLoops",
                table: "PriemCheckResultaten");

            migrationBuilder.DropColumn(
                name: "MilliSecondenOmTeBerekenen",
                table: "PriemCheckResultaten");

            migrationBuilder.DropColumn(
                name: "UitgerekendOp",
                table: "PriemCheckResultaten");

            migrationBuilder.AlterColumn<int>(
                name: "PriemKandidaatWaarde",
                table: "PriemCheckResultaten",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PriemCheckResultaten",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
