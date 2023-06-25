using Data.Models;
using Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Number).HasMaxLength(15);

            builder
                .HasOne(i => i.Client)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.ClientId);

            builder
                .HasOne(i => i.Provider)
                .WithMany(ss => ss.Invoices)
                .HasForeignKey(i => i.ProviderId);

            builder.Property(o => o.Total)
            .HasConversion(
                p => JsonSerializer.Serialize(p, (JsonSerializerOptions)null),
                p => JsonSerializer.Deserialize<Money>(p, (JsonSerializerOptions)null));
        }
    }
}
