namespace Backend.Models.Matches
{
    public class PerkStyleSelectionDto
    {
        public PerkStyleSelectionDto(int perk, int var1, int var2, int var3)
        {
            Perk = perk;
            Var1 = var1;
            Var2 = var2;
            Var3 = var3;
        }

        public int Perk { get; set; }
        public int Var1 { get; set; }
        public int Var2 { get; set; }
        public int Var3 { get; set; }
    }
}
