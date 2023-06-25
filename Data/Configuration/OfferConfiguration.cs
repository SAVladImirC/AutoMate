using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => new { o.ServiceId, o.ServiceStationId });

            builder
                .HasOne(o => o.ServiceStation)
                .WithMany(ss => ss.Offers)
                .HasForeignKey(o => o.ServiceStationId);

            builder
                .HasOne(o => o.Service)
                .WithMany(s => s.Offers)
                .HasForeignKey(o => o.ServiceId);

            builder.Property(o => o.Price)
                .HasConversion(
                    p => JsonSerializer.Serialize(p, (JsonSerializerOptions)null),
                    p => JsonSerializer.Deserialize<Money>(p, (JsonSerializerOptions)null));
        }
    }
}
