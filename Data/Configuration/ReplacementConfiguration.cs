using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class ReplacementConfiguration : IEntityTypeConfiguration<Replacement>
    {
        public void Configure(EntityTypeBuilder<Replacement> builder)
        {
            builder.HasKey(r => new { r.PerformedServiceId, r.PartId });

            builder
                .HasOne(r => r.Part)
                .WithMany(p => p.Replacements)
                .HasForeignKey(r => r.PartId);

            builder
                .HasOne(r => r.PerformedService)
                .WithMany(ps => ps.Replacements)
                .HasForeignKey(r => r.PerformedServiceId);

            builder.Property(r => r.Price)
                .HasConversion(
                    p => JsonSerializer.Serialize(p, (JsonSerializerOptions)null),
                    p => JsonSerializer.Deserialize<Money>(p, (JsonSerializerOptions)null));
        }
    }
}
