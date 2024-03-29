﻿using CapFive.Shared.DTO;
using CapFive.Web.Services.Contracts;
using CapFive.Web.Shared.ResourceFiles;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace CapFive.Web.Pages.Players
{
    public class PlayerFormBase : BaseComponent
    {
        [Parameter]
        public PlayerDTO PlayerDetails { get; set; }

        public PlayerDTO Player { get; set; }

        [Inject]
        public IStringLocalizer<Resource> Localizer { get; set; }

        [Inject]
        public IPlayersService PlayersService { get; set; }

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
                    await DisplayError.InvokeAsync(Localizer["formInvalid"]);
                    return;
                }

                var result = await PlayersService.SavePlayer(Player);
                if (Player.Id == 0)
                {
                    // redirect
                    Player.Id = result.Id;
                }

                await DisplayMessage.InvokeAsync(Localizer["changesSavedSuccess"]);
            }
            catch (Exception e)
            {
                await DisplayError.InvokeAsync(Localizer["changesSaveFailure"]);
            }
        }
    }
}
