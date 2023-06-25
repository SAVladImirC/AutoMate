using Data.ValueObjects;

namespace Data.Models
{
#nullable disable
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Path { get; set; }
        public bool IsGenerated { get; set; }
        public Money Total { get; set; }

        public int ClientId { get; set; }
        public virtual User Client { get; set; }

        public int ProviderId { get; set; }
        public virtual ServiceStation Provider { get; set; }

        public virtual List<PerformedService> PerformedServices { get; set; }
    }
}
