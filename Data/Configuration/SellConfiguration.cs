using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class SellConfiguration : IEntityTypeConfiguration<Sell>
    {
        public void Configure(EntityTypeBuilder<Sell> builder)
        {
            builder.HasKey(s => new { s.ServiceStationId, s.PartId });

            builder
                .HasOne(s => s.ServiceStation)
                .WithMany(ss => ss.Sale)
                .HasForeignKey(s => s.ServiceStationId);

            builder
                .HasOne(s => s.Part)
                .WithMany(s => s.Sells)
                .HasForeignKey(s => s.PartId);

            builder.Property(s => s.Price)
                .HasConversion(
                    p => JsonSerializer.Serialize(p, (JsonSerializerOptions)null),
                    p => JsonSerializer.Deserialize<Money>(p, (JsonSerializerOptions)null));
        }
    }
}
