using CapFive.API.Services;
using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CapFive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDTO>>> Get()
        {
            try
            {
                var result = await _tournamentService.GetTournaments();
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
