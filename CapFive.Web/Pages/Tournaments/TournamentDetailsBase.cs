using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class TournamentDetailsBase : BaseComponent
    {
        [Parameter]
        public TournamentDTO Tournament { get; set; }
    }
}
