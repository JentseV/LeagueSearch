namespace Backend.Models.Matches
{
    public class MatchDto
    {
        public MatchDto(MetadataDto metadata, InfoDto info)
        {
            this.metadata = metadata;
            this.info = info;
        }

        public MetadataDto metadata { get; set; }
        public InfoDto info { get; set; }
    }
}
