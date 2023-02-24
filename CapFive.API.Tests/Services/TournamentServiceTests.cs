using CapFive.API.Exceptions;
using CapFive.API.Services;
using CapFive.Data.Model;
using CapFive.Data.Repositories;
using CapFive.Shared.Tournament;
using MockQueryable.Moq;
using Moq;

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

        [Theory]
        public async Task GetTournament_ThrowsException_NonExistingTournament()
        {
            // given
            _tournamentRepository.Setup(t => t.GetTournamentById(It.IsAny<int>())).ReturnsAsync(null as Tournament);

            // when
            var action = () => _sut.GetTournament(1);

            // then
            Assert.ThrowsAsync<NotFoundException>(async () => await action());
        }

        [Theory]
        public async Task GetTournament_ExistingTournament_ReturnsDto()
        {
            // given
            var tournament = GetTournament();
            _tournamentRepository.Setup(r => r.GetTournamentById(1)).ReturnsAsync(tournament);

            // when
            var result = await _sut.GetTournament(tournament.Id);

            // then
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(tournament.Id));
            Assert.That(result.Name, Is.EqualTo(tournament.Name));
            Assert.That(result.Status, Is.EqualTo(tournament.Status));
            Assert.That(result.Date, Is.EqualTo(tournament.Date));
        }

        [Theory]
        public async Task StartTournament_StatusStarted_ThrowsException()
        {
            // given
            var tournament = GetTournament();
            tournament.Status = Shared.Tournament.TournamentStatus.Started;
            var tournamentList = new List<Tournament> { tournament };
            var tournamentsQuerableMock = tournamentList.BuildMock();
            _tournamentRepository.Setup(r => r.GetQuerable()).Returns(tournamentsQuerableMock);

            // when
            var action = () => _sut.StartTournament(tournament.Id);

            // then
            Assert.ThrowsAsync<BadRequestException>(async () => await action());
        }

        [Theory]
        public async Task StartTournament_TournamentNotFound_ThrowsException()
        {
            // given
            var tournamentList = new List<Tournament>();
            var tournamentsQuerableMock = tournamentList.BuildMock();
            _tournamentRepository.Setup(r => r.GetQuerable()).Returns(tournamentsQuerableMock);

            // when
            var action = () => _sut.StartTournament(1);

            // then
            Assert.ThrowsAsync<NotFoundException>(async () => await action());
        }

        [Theory]
        public async Task StartTournament_TournamentNotStarted_Startsournament()
        {
            // given
            var tournament = GetTournament();
            tournament.Status = Shared.Tournament.TournamentStatus.Created;
            tournament.Players = new List<Player>
            {
                new Player{ Id = 1 },
                new Player{ Id = 2 },
                new Player{ Id = 3 },
                new Player{ Id = 4 },
            };

            var tournamentList = new List<Tournament> { tournament };
            var tournamentsQuerableMock = tournamentList.BuildMock();
            _tournamentRepository.Setup(r => r.GetQuerable()).Returns(tournamentsQuerableMock);

            // when
            var result = await _sut.StartTournament(tournament.Id);

            // then
            Assert.That(result.Status, Is.EqualTo(TournamentStatus.Started));
            Assert.That(result.Rounds.Count(), Is.EqualTo(1));
            Assert.That(result.Rounds.First().Matchups.Count, Is.EqualTo(6));
        }

        private Tournament GetTournament()
        {
            return new Tournament
            {
                Id = 1,
                Name = "Tournament One",
                Date = new DateTime(2022, 2, 2),
                Players = new List<Player>(),
                Rounds = new List<Round>(),
                Status = TournamentStatus.Created
            };
        }
    }
}
