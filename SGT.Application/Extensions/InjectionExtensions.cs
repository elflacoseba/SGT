using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGT.Application.Interfaces;
using System.Reflection;
using SGT.Application.Services;

namespace SGT.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IApplicationUserApplication, ApplicationUserService>();
            services.AddScoped<IApplicationRoleApplication, ApplicationRoleService>();

            return services;
        }
    }
}
