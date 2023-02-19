namespace CapFive.Shared.DTO
{
    public class RoundDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MatchupDTO> Matchups { get; set; }
    }
}
