using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHuoltoSovellus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huoltopaikat",
                columns: table => new
                {
                    HuoltopaikkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Huoltopaikka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huoltopaikat", x => x.HuoltopaikkaId);
                });

            migrationBuilder.CreateTable(
                name: "Kuvat",
                columns: table => new
                {
                    KuvaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoInfoId = table.Column<int>(type: "int", nullable: false),
                    SäiliöInfoId = table.Column<int>(type: "int", nullable: false),
                    PerävaunuInfoId = table.Column<int>(type: "int", nullable: false),
                    KuvaNimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KuvaData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    KuvaTyyppi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuvat", x => x.KuvaId);
                });

            migrationBuilder.CreateTable(
                name: "Perävaunut",
                columns: table => new
                {
                    PerävaunuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rekisterinumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatsastusPvm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ADR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Välitarkastus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Määräaikaistarkastus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerävaunuInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perävaunut", x => x.PerävaunuId);
                });

            migrationBuilder.CreateTable(
                name: "Säiliöt",
                columns: table => new
                {
                    SäiliöId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SäiliöNro = table.Column<int>(type: "int", nullable: false),
                    Vakaus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Välitarkastus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Määräaikaistarkastus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SäiliöInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Säiliöt", x => x.SäiliöId);
                });

            migrationBuilder.CreateTable(
                name: "PerävaunuHuollot",
                columns: table => new
                {
                    HuollonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerävaunuId = table.Column<int>(type: "int", nullable: false),
                    HuoltoPvm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HuoltoPaikka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonKuvaus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonTyyppi = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HuoltopaikatHuoltopaikkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerävaunuHuollot", x => x.HuollonId);
                    table.ForeignKey(
                        name: "FK_PerävaunuHuollot_Huoltopaikat_HuoltopaikatHuoltopaikkaId",
                        column: x => x.HuoltopaikatHuoltopaikkaId,
                        principalTable: "Huoltopaikat",
                        principalColumn: "HuoltopaikkaId");
                    table.ForeignKey(
                        name: "FK_PerävaunuHuollot_Perävaunut_PerävaunuId",
                        column: x => x.PerävaunuId,
                        principalTable: "Perävaunut",
                        principalColumn: "PerävaunuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerävaunuInfot",
                columns: table => new
                {
                    PerävaunuId = table.Column<int>(type: "int", nullable: false),
                    InfoTxt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerävaunuInfot", x => x.PerävaunuId);
                    table.ForeignKey(
                        name: "FK_PerävaunuInfot_Perävaunut_PerävaunuId",
                        column: x => x.PerävaunuId,
                        principalTable: "Perävaunut",
                        principalColumn: "PerävaunuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autot",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rekisterinumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SäiliöId = table.Column<int>(type: "int", nullable: true),
                    KatsastusPvm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ADR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Piirturi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alkolukko = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nopeudenrajoitin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autot", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_Autot_Säiliöt_SäiliöId",
                        column: x => x.SäiliöId,
                        principalTable: "Säiliöt",
                        principalColumn: "SäiliöId");
                });

            migrationBuilder.CreateTable(
                name: "SäiliöHuollot",
                columns: table => new
                {
                    HuollonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SäiliöId = table.Column<int>(type: "int", nullable: false),
                    HuoltoPvm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HuoltoPaikka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonKuvaus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonTyyppi = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HuoltopaikatHuoltopaikkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SäiliöHuollot", x => x.HuollonId);
                    table.ForeignKey(
                        name: "FK_SäiliöHuollot_Huoltopaikat_HuoltopaikatHuoltopaikkaId",
                        column: x => x.HuoltopaikatHuoltopaikkaId,
                        principalTable: "Huoltopaikat",
                        principalColumn: "HuoltopaikkaId");
                    table.ForeignKey(
                        name: "FK_SäiliöHuollot_Säiliöt_SäiliöId",
                        column: x => x.SäiliöId,
                        principalTable: "Säiliöt",
                        principalColumn: "SäiliöId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SäiliöInfot",
                columns: table => new
                {
                    SäiliöId = table.Column<int>(type: "int", nullable: false),
                    InfoTxt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SäiliöInfot", x => x.SäiliöId);
                    table.ForeignKey(
                        name: "FK_SäiliöInfot_Säiliöt_SäiliöId",
                        column: x => x.SäiliöId,
                        principalTable: "Säiliöt",
                        principalColumn: "SäiliöId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoHuollot",
                columns: table => new
                {
                    HuollonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    HuoltoPvm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HuoltoPaikka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonKuvaus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuollonTyyppi = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HuoltopaikatHuoltopaikkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoHuollot", x => x.HuollonId);
                    table.ForeignKey(
                        name: "FK_AutoHuollot_Autot_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autot",
                        principalColumn: "AutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoHuollot_Huoltopaikat_HuoltopaikatHuoltopaikkaId",
                        column: x => x.HuoltopaikatHuoltopaikkaId,
                        principalTable: "Huoltopaikat",
                        principalColumn: "HuoltopaikkaId");
                });

            migrationBuilder.CreateTable(
                name: "AutoInfot",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    InfoTxt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoInfot", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_AutoInfot_Autot_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autot",
                        principalColumn: "AutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoHuollot_AutoId",
                table: "AutoHuollot",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoHuollot_HuoltopaikatHuoltopaikkaId",
                table: "AutoHuollot",
                column: "HuoltopaikatHuoltopaikkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Autot_SäiliöId",
                table: "Autot",
                column: "SäiliöId");

            migrationBuilder.CreateIndex(
                name: "IX_PerävaunuHuollot_HuoltopaikatHuoltopaikkaId",
                table: "PerävaunuHuollot",
                column: "HuoltopaikatHuoltopaikkaId");

            migrationBuilder.CreateIndex(
                name: "IX_PerävaunuHuollot_PerävaunuId",
                table: "PerävaunuHuollot",
                column: "PerävaunuId");

            migrationBuilder.CreateIndex(
                name: "IX_SäiliöHuollot_HuoltopaikatHuoltopaikkaId",
                table: "SäiliöHuollot",
                column: "HuoltopaikatHuoltopaikkaId");

            migrationBuilder.CreateIndex(
                name: "IX_SäiliöHuollot_SäiliöId",
                table: "SäiliöHuollot",
                column: "SäiliöId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHuollot");

            migrationBuilder.DropTable(
                name: "AutoInfot");

            migrationBuilder.DropTable(
                name: "Kuvat");

            migrationBuilder.DropTable(
                name: "PerävaunuHuollot");

            migrationBuilder.DropTable(
                name: "PerävaunuInfot");

            migrationBuilder.DropTable(
                name: "SäiliöHuollot");

            migrationBuilder.DropTable(
                name: "SäiliöInfot");

            migrationBuilder.DropTable(
                name: "Autot");

            migrationBuilder.DropTable(
                name: "Perävaunut");

            migrationBuilder.DropTable(
                name: "Huoltopaikat");

            migrationBuilder.DropTable(
                name: "Säiliöt");
        }
    }
}
