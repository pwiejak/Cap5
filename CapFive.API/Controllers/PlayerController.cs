using System.Net;
using CapFive.API.Services;
using CapFive.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

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
    }
}
