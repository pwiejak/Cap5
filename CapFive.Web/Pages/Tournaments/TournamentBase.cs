using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        public TournamentDTO Tournament { get; set; }
        public List<PlayerSelectionDTO> AllPlayers { get; set; }

        [Inject]
        public ITournamentsService TournamentsService { get; set; }
        [Inject]
        public IPlayersService PlayerService { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Tournament = Id > 0
                    ? await TournamentsService.GetTournament(Id)
                    : new TournamentDTO();
                AllPlayers = (await PlayerService.GetPlayers())
                    .Select(p => new PlayerSelectionDTO
                    {
                        Player = p,
                        IsSelected = Tournament.Players.Any(pt => pt.Id == p.Id)
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
