using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<VehicleService>();
            services.AddTransient<PerformedServiceService>();
            services.AddTransient<ServiceService>();
            services.AddTransient<PartService>();
            services.AddTransient<ServiceStationService>();
            services.AddTransient<InvoiceService>();
            return services;
        }
    }
}
