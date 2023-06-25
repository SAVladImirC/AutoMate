using Data.ValueObjects;

namespace Data.Models
{
#nullable disable
    public class Offer
    {
        public Money Price { get; set; }

        public int ServiceStationId { get; set; }
        public virtual ServiceStation ServiceStation { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
