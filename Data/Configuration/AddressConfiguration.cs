using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Country).HasMaxLength(50);
            builder.Property(a => a.City).HasMaxLength(50);
            builder.Property(a => a.Street).HasMaxLength(50);
            builder.Property(a => a.PostalCode).HasMaxLength(50);

            builder
                .HasOne(a => a.User)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.UserId);
        }
    }
}