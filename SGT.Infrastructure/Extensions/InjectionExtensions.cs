using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGT.Infrastructure.Persistence.Context;
using SGT.Infrastructure.Persistence.Repositories;
using SGT.Infrastructure.Models;
using SGT.Infrastructure.Persistence.Interfaces;
using System.Reflection;

namespace SGT.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SGTDB_Connection")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddIdentity<ApplicationUserModel, ApplicationRoleModel>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationRoleRepository, ApplicationRoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            return services;
        }
    }
}
