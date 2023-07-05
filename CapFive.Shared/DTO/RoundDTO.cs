namespace CapFive.Shared.DTO
{
    public class RoundDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MatchupDTO> Matchups { get; set; }

        public MatchupDTO? GetMatchupForPlayers(int playerId, int opponentId)
        {
            return Matchups.FirstOrDefault(m => m.HomePlayer.Id == playerId && m.AwayPlayer.Id == opponentId
            || m.AwayPlayer.Id == playerId && m.HomePlayer.Id == opponentId);
        }
    }
}
