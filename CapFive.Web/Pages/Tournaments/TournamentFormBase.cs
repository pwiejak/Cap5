using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using CapFive.Web.Shared.ResourceFiles;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentFormBase : BaseComponent
    {
        [Parameter]
        public TournamentDTO TournamentDto { get; set; }
        public TournamentDTO Tournament { get; set; }

        [Parameter]
        public List<PlayerSelectionDTO> AllPlayers { get; set; }

        [Inject]
        public IStringLocalizer<Resource> Localizer { get; set; }

        [Inject]
        public ITournamentsService TournamentsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Tournament = TournamentDto != null
                ? TournamentDto
                : new TournamentDTO();
        }

        public async Task FormSubmited(EditContext context)
        {
            try
            {
                if (!context.Validate())
                {
                    await DisplayError.InvokeAsync(Localizer["formInvalid"]);
                    return;
                }

                var result = await TournamentsService.SaveTournament(Tournament);
                if (Tournament.Id == 0)
                {
                    // redirect
                    Tournament.Id = result.Id;
                }

                await DisplayMessage.InvokeAsync(Localizer["changesSavedSuccess"]);
            }
            catch (Exception e)
            {
                await DisplayError.InvokeAsync(Localizer["changesSaveFailure"]);
            }
        }

        public async Task StartTournament(EditContext context)
        {
            if (!context.Validate())
            {
                await DisplayError.InvokeAsync(Localizer["formInvalid"]);
                return;
            }

            if (Tournament.Status == CapFive.Shared.Tournament.TournamentStatus.Started) return;

            Tournament.Status = CapFive.Shared.Tournament.TournamentStatus.Started;
            await TournamentsService.SaveTournament(Tournament);
            NavigationManager.NavigateTo($"tournament/{Tournament.Id}", true);
        }

        public void SelectPlayer(PlayerSelectionDTO player)
        {
            if (player == null)
                return;

            player.IsSelected = true;
            Tournament.Players.Add(player.Player);
        }

        public void UnselectPlayer(PlayerDTO player)
        {
            if (player == null)
                return;

            var selection = AllPlayers.First(p => p.Player.Id == player.Id);
            selection.IsSelected = false;
            Tournament.Players.Remove(player);
        }
    }
}
