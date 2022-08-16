using CapFive.Shared.DTO;

namespace CapFive.Web.Services.Contracts
{
    public interface IPlayersService
    {
        Task<IEnumerable<PlayerDTO>> GetPlayers();
    }
}
