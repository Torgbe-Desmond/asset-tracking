using Asset_Tracking.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asset_Tracking.Application
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDi(this IServiceCollection services, IConfiguration configuration)
        {
            // Register application services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddInfrastructureDi(configuration);
            return services;
        }
    }
}
