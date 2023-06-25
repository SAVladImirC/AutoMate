using Data.ValueObjects;
using System.Text.Json.Serialization;

namespace Data.Models
{
#nullable disable
    public class Replacement
    {
        public Money Price { get; set; }

        [JsonIgnore]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [JsonIgnore]
        public int PerformedServiceId { get; set; }
        [JsonIgnore]
        public virtual PerformedService PerformedService { get; set; }
    }
}
