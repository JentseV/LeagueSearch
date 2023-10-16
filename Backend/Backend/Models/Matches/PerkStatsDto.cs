namespace Backend.Models.Matches
{
    public class PerkStatsDto
    {
        public PerkStatsDto(int defense, int flex, int offense)
        {
            Defense = defense;
            Flex = flex;
            Offense = offense;
        }

        public int Defense { get; set; }
        public int Flex { get; set; }
        public int Offense { get; set; }

    }
}
