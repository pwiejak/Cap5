using CapFive.Data.Model;
using CapFive.Shared.DTO;

namespace CapFive.API.DTO
{
    public static class DtoMappings
    {
        public static IEnumerable<PlayerDTO> ToDtos(this IEnumerable<Player> players)
        {
            return players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
            });
        }
    }
}
