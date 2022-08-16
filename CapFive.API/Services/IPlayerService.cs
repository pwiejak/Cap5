using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDTO>> GetPlayers();
    }
}
