using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TenantPM.API.Mapping;

namespace TenantPM.API
{
    public static class APILayerServiceRegistration
    {
        // Method registers AutoMapper profiles in the API layer
        public static IServiceCollection AddApiAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(APIProfiles).Assembly);
            return services;
        }
    }
}
