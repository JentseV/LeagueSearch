namespace Backend.Models.Matches
{
    public class PerksDto
    {
        public PerksDto(PerkStatsDto statPerks, List<PerkStyleDto> styles)
        {
            this.StatPerks = statPerks;
            this.Styles = styles;
        }

        public PerkStatsDto StatPerks { get; set; }
        public List<PerkStyleDto> Styles { get; set; }
    }
}
