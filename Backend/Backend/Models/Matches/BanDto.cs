namespace Backend.Models.Matches
{
    public class BanDto
    {
        public BanDto(int championId, int pickTurn)
        {
            ChampionId = championId;
            PickTurn = pickTurn;
        }

        public int ChampionId { get; set; }
        public int PickTurn { get; set; }
    }
}
