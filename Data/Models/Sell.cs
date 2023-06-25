using Data.ValueObjects;

namespace Data.Models
{
#nullable disable
    public class Sell
    {
        public Money Price { get; set; }

        public int ServiceStationId { get; set; }
        public virtual ServiceStation ServiceStation { get; set; }

        public int PartId { get; set; }
        public virtual Part Part { get; set; }
    }
}
