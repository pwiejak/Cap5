using CapFive.Shared.DTO;
using CapFive.Web.Pages.Common;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentDetailsBase : BaseComponent
    {
        [Parameter]
        public TournamentDTO Tournament { get; set; }

        public PlayerDTO PlayerOne { get; set; }
        public PlayerDTO PlayerTwo { get; set; }

        public Modal? _modal { get; set; }

        public void Open(PlayerDTO p1, PlayerDTO p2)
        {
            if (p1.Id == p2.Id)
                return;

            PlayerOne = p1;
            PlayerTwo = p2;
            _modal?.Open();
        }

    }
}
