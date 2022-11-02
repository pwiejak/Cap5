using CapFive.Shared.DTO;

namespace CapFive.Web.Services.Contracts
{
    public interface IPlayersService
    {
        Task<IEnumerable<PlayerDTO>> GetPlayers();
        Task<PlayerDTO> GetPlayer(int id);
        Task<PlayerDTO> SavePlayer(PlayerDTO player);
    }
}
