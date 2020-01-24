using Backend.Data.Ef.Repository;
using Backend.Data.Ef.Repository.Interfaces;
using Backend.Services.Concrete;
using Backend.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            return services;
        }
    }
}
