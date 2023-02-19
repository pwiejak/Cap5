using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapFive.Data.Migrations
{
    public partial class PlayerTournamentNavPropertyRenameToTournaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTournament_Tournaments_TournamentId",
                table: "PlayerTournament");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "PlayerTournament",
                newName: "TournamentsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTournament_TournamentId",
                table: "PlayerTournament",
                newName: "IX_PlayerTournament_TournamentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTournament_Tournaments_TournamentsId",
                table: "PlayerTournament",
                column: "TournamentsId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTournament_Tournaments_TournamentsId",
                table: "PlayerTournament");

            migrationBuilder.RenameColumn(
                name: "TournamentsId",
                table: "PlayerTournament",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTournament_TournamentsId",
                table: "PlayerTournament",
                newName: "IX_PlayerTournament_TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTournament_Tournaments_TournamentId",
                table: "PlayerTournament",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
