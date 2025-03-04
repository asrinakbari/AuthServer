using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application.ServiceExtensions
{
    public static class AutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
