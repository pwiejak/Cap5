using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDTO>> GetPlayers();
        Task<PlayerDTO> GetPlayer(int id);
        Task<PlayerDTO> SavePlayer(PlayerDTO playerDto);
    }
}
