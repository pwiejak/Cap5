using CapFive.API.Exceptions;
using CapFive.API.Services;
using CapFive.Data.Model;
using CapFive.Data.Repositories;
using Moq;
using Xunit;

namespace CapFive.API.Tests.Services
{
    public class TournamentServiceTests
    {
        private readonly Mock<ITournamentRepository> _tournamentRepository;
        private readonly Mock<IPlayerRepository> _playerRepository;
        private readonly ITournamentService _sut;

        public TournamentServiceTests()
        {
            _tournamentRepository = new Mock<ITournamentRepository>();
            _playerRepository = new Mock<IPlayerRepository>();

            _sut = new TournamentService(_tournamentRepository.Object, _playerRepository.Object);
        }

        [Fact]
        public async Task GetTournament_ThrowsException_NonExistingTournament()
        {
            // given
            _tournamentRepository.Setup(t => t.GetTournamentById(It.IsAny<int>())).ReturnsAsync(null as Tournament);

            // when
            var action = () => _sut.GetTournament(1);

            // then
            Assert.ThrowsAsync<NotFoundException>(async () => await action());
        }
    }
}
