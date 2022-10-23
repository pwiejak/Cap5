using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Players
{
    public class DisplayPlayersListBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<PlayerDTO> Players { get; set; }
    }
}
