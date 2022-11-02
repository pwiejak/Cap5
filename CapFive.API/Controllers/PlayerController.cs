using CapFive.API.Exceptions;
using CapFive.API.Services;
using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CapFive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> Get()
        {
            try
            {
                var result = await _playerService.GetPlayers();
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
        {
            try
            {
                var result = await _playerService.GetPlayer(id);
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
        public async Task<ActionResult<PlayerDTO>> SavePlayer(PlayerDTO player)
        {
            try
            {
                var result = await _playerService.SavePlayer(player);
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

    }
}
