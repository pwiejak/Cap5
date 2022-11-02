using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Players
{
    public class PlayerDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        public PlayerDTO Player { get; set; }

        [Inject]
        public IPlayersService PlayersService { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Player = Id > 0
                    ? await PlayersService.GetPlayer(Id)
                    : new PlayerDTO();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
