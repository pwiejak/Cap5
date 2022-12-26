using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Tournaments
{
    public class DisplayTournamentsListBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<TournamentDTO> Tournaments { get; set; }
    }
}
