using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZespolBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixRelacji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KierownikZespoluId1",
                table: "Zespoly",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZespolId1",
                table: "Czlonkowie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zespoly_KierownikZespoluId1",
                table: "Zespoly",
                column: "KierownikZespoluId1");

            migrationBuilder.CreateIndex(
                name: "IX_Czlonkowie_ZespolId1",
                table: "Czlonkowie",
                column: "ZespolId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Czlonkowie_Zespoly_ZespolId1",
                table: "Czlonkowie",
                column: "ZespolId1",
                principalTable: "Zespoly",
                principalColumn: "ZespolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zespoly_Kierownicy_KierownikZespoluId1",
                table: "Zespoly",
                column: "KierownikZespoluId1",
                principalTable: "Kierownicy",
                principalColumn: "KierownikZespoluId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Czlonkowie_Zespoly_ZespolId1",
                table: "Czlonkowie");

            migrationBuilder.DropForeignKey(
                name: "FK_Zespoly_Kierownicy_KierownikZespoluId1",
                table: "Zespoly");

            migrationBuilder.DropIndex(
                name: "IX_Zespoly_KierownikZespoluId1",
                table: "Zespoly");

            migrationBuilder.DropIndex(
                name: "IX_Czlonkowie_ZespolId1",
                table: "Czlonkowie");

            migrationBuilder.DropColumn(
                name: "KierownikZespoluId1",
                table: "Zespoly");

            migrationBuilder.DropColumn(
                name: "ZespolId1",
                table: "Czlonkowie");
        }
    }
}
