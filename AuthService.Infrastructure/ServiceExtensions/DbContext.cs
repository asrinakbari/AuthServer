using AuthService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.ServiceExtensions
{
    public static class DbContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthContext")));

            return services;
        }
    }
}
    