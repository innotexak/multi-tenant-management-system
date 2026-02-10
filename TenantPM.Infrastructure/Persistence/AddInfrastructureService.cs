using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.Common.Interfaces.Authorization;
using TenantPM.Infrastructure.Auth;
using TenantPM.Infrastructure.Authorization;
using TenantPM.Infrastructure.Repositories;

namespace TenantPM.Infrastructure.Persistence
{
    public static class AddInfrastructureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TenantConnectionString"),
                     b => b.MigrationsAssembly("TenantPM.Infrastructure") 
                 ));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IProjectAuthorizationService, ProjectAuthorizationService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
