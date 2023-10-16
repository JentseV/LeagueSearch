namespace Backend.Models.Matches
{
    public class TeamDto
    {
        public TeamDto(List<BanDto> bans, ObjectivesDto objectives, int teamId, bool win)
        {
            Bans = bans;
            Objectives = objectives;
            TeamId = teamId;
            Win = win;
        }

        public List<BanDto> Bans { get; set; }
        public ObjectivesDto Objectives { get; set; }
        public int TeamId { get; set; }
        public bool Win { get; set; }
    }
}
