namespace Data.Models
{
#nullable disable
    public class Part
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Sell> Sells { get; set; }

        public virtual List<Replacement> Replacements { get; set; }
    }
}
