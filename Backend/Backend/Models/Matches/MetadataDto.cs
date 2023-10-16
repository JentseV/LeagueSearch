namespace Backend.Models.Matches
{
    public class MetadataDto
    {
        public MetadataDto(string dataVersion, string matchId, List<string> participants)
        {
            this.dataVersion = dataVersion;
            this.matchId = matchId;
            this.participants = participants;
        }

        public string dataVersion { get; set; }
        public string matchId { get; set; }
        public List<string> participants { get; set; }
    }
}
