using Data.Configuration;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AutoMateDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PerformedService> PerformedServices { get; set; }
        public DbSet<Replacement> Replacements { get; set; }
        public DbSet<Sell> Sales { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceStation> ServiceStations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public AutoMateDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
            new BrandConfiguration().Configure(modelBuilder.Entity<Brand>());
            new InvoiceConfiguration().Configure(modelBuilder.Entity<Invoice>());
            new ModelConfiguration().Configure(modelBuilder.Entity<Model>());
            new OfferConfiguration().Configure(modelBuilder.Entity<Offer>());
            new PartConfiguration().Configure(modelBuilder.Entity<Part>());
            new PerformedServiceConfiguration().Configure(modelBuilder.Entity<PerformedService>());
            new ReplacementConfiguration().Configure(modelBuilder.Entity<Replacement>());
            new SellConfiguration().Configure(modelBuilder.Entity<Sell>());
            new ServiceConfiguration().Configure(modelBuilder.Entity<Service>());
            new ServiceStationConfiguration().Configure(modelBuilder.Entity<ServiceStation>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new VehicleConfiguration().Configure(modelBuilder.Entity<Vehicle>());
        }
    }
}
