using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutoMateDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("AutoMate"));
                o.EnableDetailedErrors();
                o.EnableSensitiveDataLogging();
            });

            services.AddTransient(typeof(GeneralRepository<>));
            services.AddTransient<UserRepository>();
            services.AddTransient<VehicleRepository>();
            services.AddTransient<PerformedServiceRepository>();
            services.AddTransient<ServiceRepository>();
            services.AddTransient<PartRepository>();
            services.AddTransient<ServiceStationRepository>();
            services.AddTransient<InvoiceRepository>();
            services.AddTransient<ReplacementRepository>();
            services.AddTransient<OfferRepository>();
            services.AddTransient<SaleRepository>();
            return services;
        }
    }
}
