using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CapFive.Web.Pages.Players
{
    public class PlayerFormBase : ComponentBase
    {
        [Parameter]
        public PlayerDTO PlayerDetails { get; set; }

        public PlayerDTO Player { get; set; }

        [Inject]
        public IPlayersService PlayersService { get; set; }

        [CascadingParameter(Name = "InfoToastEvent")]
        public EventCallback<string> DisplayMessage { get; set; }

        [CascadingParameter(Name = "ErrorToastEvent")]
        public EventCallback<string> DisplayError { get; set; }

        protected override void OnInitialized()
        {
            Player = PlayerDetails != null
                ? PlayerDetails
                : new PlayerDTO();
        }

        public async Task FormSubmited(EditContext context)
        {
            try
            {
                if (!context.Validate())
                {
                    await DisplayError.InvokeAsync("Form invalid");
                    return;
                }

                var result = await PlayersService.SavePlayer(Player);
                if (Player.Id == 0)
                {
                    // redirect
                    Player.Id = result.Id;
                }

                await DisplayMessage.InvokeAsync("Changes saved successfaully");
            }
            catch (Exception e)
            {
                await DisplayError.InvokeAsync(e.Message);
            }
        }
    }
}
