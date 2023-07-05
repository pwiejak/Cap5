using CapFive.API.Exceptions;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TournamentDTO>> GetTournament(int id)
        {
            try
            {
                var result = await _tournamentService.GetTournament(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TournamentDTO>> SaveTournament(TournamentDTO tournament)
        {
            try
            {
                var result = await _tournamentService.SaveTournament(tournament);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("{tournamentId}/start")]
        public async Task<ActionResult<TournamentDTO>> StartTournament([FromRoute] int tournamentId)
        {
            try
            {
                var result = await _tournamentService.StartTournament(tournamentId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("{tournamentId}/addRound")]
        public async Task<ActionResult<TournamentDTO>> AddRound([FromRoute] int tournamentId)
        {
            try
            {
                var result = await _tournamentService.AddRound(tournamentId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
