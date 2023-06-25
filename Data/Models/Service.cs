namespace Data.Models
{
#nullable disable
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual PerformedService PerformedService { get; set; }

        public virtual List<Offer> Offers { get; set; }
    }
}
