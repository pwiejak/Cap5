using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapFive.Data.Migrations
{
    public partial class PlayersTournamentsRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "PlayerTournament",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournament", x => new { x.PlayersId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournament_TournamentId",
                table: "PlayerTournament",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournament");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
