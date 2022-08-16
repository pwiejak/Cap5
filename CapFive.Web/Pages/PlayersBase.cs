using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages
{
    public class PlayersBase : ComponentBase
    {
        [Inject]
        public IPlayersService PlayersService { get; set; }

        public IEnumerable<PlayerDTO> Players { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Players = await PlayersService.GetPlayers();
        }
    }
}
