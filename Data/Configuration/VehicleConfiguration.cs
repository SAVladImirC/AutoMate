using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Vin).HasMaxLength(17);
            builder.Property(v => v.RegistrationPlate).HasMaxLength(15);

            builder
                .HasOne(v => v.Model)
                .WithOne(m => m.Vehicle)
                .HasForeignKey<Vehicle>(v => v.ModelId);

            builder
                .HasOne(v => v.Owner)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.OwnerId);
        }
    }
}
