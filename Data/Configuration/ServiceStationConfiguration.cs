using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class ServiceStationConfiguration : IEntityTypeConfiguration<ServiceStation>
    {
        public void Configure(EntityTypeBuilder<ServiceStation> builder)
        {
            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.Name).HasMaxLength(256);

            builder
                .HasOne(ss => ss.Owner)
                .WithMany(u => u.ServiceStations)
                .HasForeignKey(ss => ss.OwnerId);

            builder.Property(s => s.Location)
                .HasConversion(
                    l => JsonSerializer.Serialize(l, (JsonSerializerOptions)null),
                    l => JsonSerializer.Deserialize<Location>(l, (JsonSerializerOptions)null));
        }
    }
}
