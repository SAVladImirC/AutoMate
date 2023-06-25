using Data.ValueObjects;
using System.Text.Json.Serialization;

namespace Data.Models
{
#nullable disable
    public class PerformedService
    {
        public int Id { get; set; }
        public Money Price { get; set; }
        public DateTime PerformedOn { get; set; }
        public float Mileage { get; set; }

        public virtual List<Replacement> Replacements { get; set; }

        [JsonIgnore]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [JsonIgnore]
        public int VehicleId { get; set; }
        [JsonIgnore]
        public virtual Vehicle Vehicle { get; set; }

        [JsonIgnore]
        public int ServiceStationId { get; set; }
        public virtual ServiceStation ServiceStation { get; set; }

        public int InvoiceId { get; set; }
        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }
    }
}
