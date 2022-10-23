using CapFive.API.DTO;
using CapFive.Data.Repositories;
using CapFive.Shared.DTO;

namespace CapFive.API.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayerDTO> GetPlayer(int id)
        {
            var player = await _playerRepository.GetPlayerById(id);
            if(player == null)
            {
                throw new Exception($"Player with id: {id} does not exist");
            }

            return player.ToDto();
        }

        public async Task<IEnumerable<PlayerDTO>> GetPlayers()
        {
            var players = await _playerRepository.GetPlayers();

            return players.ToDtos();
        }
    }
}
