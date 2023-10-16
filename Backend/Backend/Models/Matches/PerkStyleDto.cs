namespace Backend.Models.Matches
{
    public class PerkStyleDto
    {
        public PerkStyleDto(string description, List<PerkStyleSelectionDto> selections, int style)
        {
            Description = description;
            Selections = selections;
            Style = style;
        }

        public string Description { get; set; }
        public List<PerkStyleSelectionDto> Selections { get; set; }
        public int Style { get; set; }
    }
}
