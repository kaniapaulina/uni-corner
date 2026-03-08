using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZespolBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kierownicy",
                columns: table => new
                {
                    KierownikZespoluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiczbaProjektow = table.Column<int>(type: "int", nullable: false),
                    DoswiadczenieKierownika = table.Column<int>(type: "int", nullable: false),
                    TelefonKontaktowy = table.Column<long>(type: "bigint", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierownicy", x => x.KierownikZespoluId);
                });

            migrationBuilder.CreateTable(
                name: "Zespoly",
                columns: table => new
                {
                    ZespolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KierownikZespoluId = table.Column<int>(type: "int", nullable: false),
                    LiczbaAktywnychCzlonkowZespolu = table.Column<int>(type: "int", nullable: false),
                    NazwaZespolu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zespoly", x => x.ZespolId);
                    table.ForeignKey(
                        name: "FK_Zespoly_Kierownicy_KierownikZespoluId",
                        column: x => x.KierownikZespoluId,
                        principalTable: "Kierownicy",
                        principalColumn: "KierownikZespoluId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Czlonkowie",
                columns: table => new
                {
                    CzłonekZespoluld = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZespolId = table.Column<int>(type: "int", nullable: false),
                    DataWstapienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FunkcjaWZespole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czlonkowie", x => x.CzłonekZespoluld);
                    table.ForeignKey(
                        name: "FK_Czlonkowie_Zespoly_ZespolId",
                        column: x => x.ZespolId,
                        principalTable: "Zespoly",
                        principalColumn: "ZespolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Czlonkowie_ZespolId",
                table: "Czlonkowie",
                column: "ZespolId");

            migrationBuilder.CreateIndex(
                name: "IX_Zespoly_KierownikZespoluId",
                table: "Zespoly",
                column: "KierownikZespoluId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Czlonkowie");

            migrationBuilder.DropTable(
                name: "Zespoly");

            migrationBuilder.DropTable(
                name: "Kierownicy");
        }
    }
}
