namespace Backend.Models.Matches
{
    public class ObjectiveDto
    {
        public ObjectiveDto(bool first, int kills)
        {
            First = first;
            Kills = kills;
        }

        public bool First { get; set; }
        public int Kills { get; set; }
    }
}
