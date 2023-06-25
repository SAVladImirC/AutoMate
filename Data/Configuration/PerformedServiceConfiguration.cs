using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class PerformedServiceConfiguration : IEntityTypeConfiguration<PerformedService>
    {
        public void Configure(EntityTypeBuilder<PerformedService> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder
                .HasOne(ps => ps.Service)
                .WithOne(s => s.PerformedService)
                .HasForeignKey<PerformedService>(ps => ps.ServiceId);

            builder
                .HasOne(ps => ps.Invoice)
                .WithMany(i => i.PerformedServices)
                .HasForeignKey(ps => ps.InvoiceId);

            builder
                .HasOne(ps => ps.ServiceStation)
                .WithMany(ss => ss.PerformedServices)
                .HasForeignKey(ps => ps.ServiceStationId);

            builder
                .HasOne(ps => ps.Vehicle)
                .WithMany(v => v.PerformedServices)
                .HasForeignKey(ps => ps.VehicleId);


            builder.Property(ps => ps.Price)
                .HasConversion(
                    p => JsonSerializer.Serialize(p, (JsonSerializerOptions)null),
                    p => JsonSerializer.Deserialize<Money>(p, (JsonSerializerOptions)null));
        }
    }
}
