namespace CapFive.Shared.DTO
{
    public class MatchupDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PlayerDTO HomePlayer { get; set; }

        public PlayerDTO AwayPlayer { get; set; }

        public PlayerDTO? WinnerPlayer { get; set; }
    }
}
