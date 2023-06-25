using Data.ValueObjects;

namespace Data.Models
{
#nullable disable
    public class ServiceStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundedOn { get; set; }
        public Location Location { get; set; }

        public virtual List<Offer> Offers { get; set; }

        public virtual List<Sell> Sale { get; set; }

        public virtual List<PerformedService> PerformedServices { get; set; }

        public virtual List<Invoice> Invoices { get; set; }

        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
    }
}
