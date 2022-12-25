using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentsBase : ComponentBase
    {
        [Inject]
        public ITournamentsService TournamentsService { get; set; }

        public IEnumerable<TournamentDTO> Tournaments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tournaments = await TournamentsService.GetTournaments();
        }
    }
}
