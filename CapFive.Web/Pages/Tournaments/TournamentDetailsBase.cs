using CapFive.Shared.DTO;
using CapFive.Web.Pages.Common;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentDetailsBase : BaseComponent
    {
        [Parameter]
        public TournamentDTO Tournament { get; set; }

        [Inject]
        public IMatchupsService MatchupsService { get; set; }

        public int RoundId { get; set; }
        public PlayerDTO PlayerOne { get; set; }
        public PlayerDTO PlayerTwo { get; set; }
        public MatchupDTO? Matchup { get; set; }
        public PlayerDTO? Winner { get; set; }

        public Modal? _modal { get; set; }

        public void Open(PlayerDTO p1, PlayerDTO p2, int roundId)
        {
            if (p1.Id == p2.Id)
                return;

            var matchup = Tournament.Rounds
                .First(r => r.Id == roundId)
                .Matchups.First(m => m.HomePlayer.Id == p1.Id && m.AwayPlayer.Id == p2.Id || m.HomePlayer.Id == p2.Id && m.AwayPlayer.Id == p1.Id);

            Winner = matchup.WinnerPlayer;
            Matchup = matchup;

            PlayerOne = p1;
            PlayerTwo = p2;

            _modal?.Open();
        }

        public void SelectWinner(PlayerDTO winner)
        {
            Winner = winner;
        }

        public async Task SaveGame()
        {
            await MatchupsService.SetWinner(Matchup.Id, Winner.Id);
            Matchup.WinnerPlayer = Winner;

            _modal?.Close();
        }
    }
}
