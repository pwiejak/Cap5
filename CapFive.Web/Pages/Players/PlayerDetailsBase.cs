using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
        public string InfoMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Player = await PlayersService.GetPlayer(Id);
                InfoMessage = string.Empty;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public async Task FormSubmited(EditContext context)
        {
            try
            {
                if (!context.Validate())
                {
                    InfoMessage = "Form invalid";
                    return;
                }

                InfoMessage = string.Empty;
                var result = await PlayersService.SavePlayer(Player);
                if (Player.Id == 0)
                {
                    Player.Id = result.Id;
                }

                InfoMessage = "Changes saved successfaully";
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
