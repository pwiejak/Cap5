using CapFive.API.DTO;
using CapFive.API.Exceptions;
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
            if (player == null)
            {
                throw new NotFoundException($"Player with id: {id} does not exist");
            }

            return player.ToDto();
        }

        public async Task<IEnumerable<PlayerDTO>> GetPlayers()
        {
            var players = await _playerRepository.GetPlayers();

            return players.ToDtos();
        }

        public async Task<PlayerDTO> SavePlayer(PlayerDTO playerDto)
        {
            if (playerDto == null)
                throw new ArgumentNullException(nameof(PlayerDTO));

            var player = playerDto.Id > 0 ? await _playerRepository.GetPlayerById(playerDto.Id) : new Data.Model.Player();
            player.Name = playerDto.Name;
            player.Surname = playerDto.Surname;
            player.Email = playerDto.Email;

            if (playerDto.Id > 0)
            {
                _playerRepository.Update(player);
            }
            else
            {
                _playerRepository.Add(player);
            }

            await _playerRepository.SaveAsync();

            return player.ToDto();
        }
    }
}
