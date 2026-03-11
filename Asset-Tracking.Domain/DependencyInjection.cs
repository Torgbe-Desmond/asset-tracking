using Microsoft.Extensions.DependencyInjection;

namespace Asset_Tracking.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDi(this IServiceCollection services)
        {
            // Register application services here
            return services;
        }
    }
}
