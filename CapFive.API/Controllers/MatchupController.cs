using CapFive.API.Services;
using CapFive.Shared.DTO;
using CapFive.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CapFive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchupController : ControllerBase
    {
        private readonly IMatchupService _matchupService;

        public MatchupController(IMatchupService matchupService)
        {
            _matchupService = matchupService;
        }

        [HttpPost("{matchupId}/setWinner")]
        public async Task<ActionResult<MatchupDTO>> SetWinner([FromRoute] int matchupId, SetMatchupWinnerRequest request)
        {
            var matchup = await _matchupService.SetWinner(matchupId, request.PlayerId);

            return Ok(matchup);
        }
    }
}
