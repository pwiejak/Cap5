using CapFive.API.DTO;
using CapFive.Data.Model;
using CapFive.Shared.DTO;

namespace CapFive.API.Tests.DTO
{
    public class DtoMappingsTests
    {
        private int PlayerId = 1;
        private string PlayerName = "Player Name";
        private string PlayerSurname = "Player Surname";
        private string PlayerEmail = "email@address.com";

        private int TournamentId = 11;
        private string TournamentName = "Tournament Name";
        private DateTime TournamentDate = new DateTime(2022, 2, 2);

        [Theory]
        public void Player_ToDto_Maps()
        {
            // given
            var player = CreatePlayerModel();

            // when
            var result = player.ToDto();

            // then
            Assert.That(result.Id, Is.EqualTo(player.Id));
            Assert.That(result.Name, Is.EqualTo(player.Name));
            Assert.That(result.Surname, Is.EqualTo(player.Surname));
            Assert.That(result.Email, Is.EqualTo(player.Email));
        }

        [Theory]
        public void Player_ToModel_Maps()
        {
            // given
            var player = CreatePlayerDto();

            // when
            var result = player.ToModel();

            // then
            Assert.That(result.Id, Is.EqualTo(player.Id));
            Assert.That(result.Name, Is.EqualTo(player.Name));
            Assert.That(result.Surname, Is.EqualTo(player.Surname));
            Assert.That(result.Email, Is.EqualTo(player.Email));
        }

        private Player CreatePlayerModel()
        {
            return new Player
            {
                Id = PlayerId,
                Name = PlayerName,
                Surname = PlayerSurname,
                Email = PlayerEmail
            };
        }

        private PlayerDTO CreatePlayerDto()
        {
            return new PlayerDTO
            {
                Id = PlayerId,
                Name = PlayerName,
                Surname = PlayerSurname,
                Email = PlayerEmail
            };
        }
    }
}
