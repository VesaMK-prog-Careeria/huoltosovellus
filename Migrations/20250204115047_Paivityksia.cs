using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHuoltoSovellus.Migrations
{
    /// <inheritdoc />
    public partial class Paivityksia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Välitarkastus",
                table: "Säiliöt",
                newName: "VälitarkastusPvm");

            migrationBuilder.RenameColumn(
                name: "Vakaus",
                table: "Säiliöt",
                newName: "VakausPvm");

            migrationBuilder.RenameColumn(
                name: "Määräaikaistarkastus",
                table: "Säiliöt",
                newName: "MääräaikaistarkastusPvm");

            migrationBuilder.RenameColumn(
                name: "Välitarkastus",
                table: "Perävaunut",
                newName: "VälitarkastusPvm");

            migrationBuilder.RenameColumn(
                name: "Määräaikaistarkastus",
                table: "Perävaunut",
                newName: "MääräaikaistarkastusPvm");

            migrationBuilder.RenameColumn(
                name: "ADR",
                table: "Perävaunut",
                newName: "ADRPvm");

            migrationBuilder.RenameColumn(
                name: "Piirturi",
                table: "Autot",
                newName: "PiirturiPvm");

            migrationBuilder.RenameColumn(
                name: "Nopeudenrajoitin",
                table: "Autot",
                newName: "NopeudenrajoitinPvm");

            migrationBuilder.RenameColumn(
                name: "Alkolukko",
                table: "Autot",
                newName: "AlkolukkoPvm");

            migrationBuilder.RenameColumn(
                name: "ADR",
                table: "Autot",
                newName: "ADRPvm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VälitarkastusPvm",
                table: "Säiliöt",
                newName: "Välitarkastus");

            migrationBuilder.RenameColumn(
                name: "VakausPvm",
                table: "Säiliöt",
                newName: "Vakaus");

            migrationBuilder.RenameColumn(
                name: "MääräaikaistarkastusPvm",
                table: "Säiliöt",
                newName: "Määräaikaistarkastus");

            migrationBuilder.RenameColumn(
                name: "VälitarkastusPvm",
                table: "Perävaunut",
                newName: "Välitarkastus");

            migrationBuilder.RenameColumn(
                name: "MääräaikaistarkastusPvm",
                table: "Perävaunut",
                newName: "Määräaikaistarkastus");

            migrationBuilder.RenameColumn(
                name: "ADRPvm",
                table: "Perävaunut",
                newName: "ADR");

            migrationBuilder.RenameColumn(
                name: "PiirturiPvm",
                table: "Autot",
                newName: "Piirturi");

            migrationBuilder.RenameColumn(
                name: "NopeudenrajoitinPvm",
                table: "Autot",
                newName: "Nopeudenrajoitin");

            migrationBuilder.RenameColumn(
                name: "AlkolukkoPvm",
                table: "Autot",
                newName: "Alkolukko");

            migrationBuilder.RenameColumn(
                name: "ADRPvm",
                table: "Autot",
                newName: "ADR");
        }
    }
}
