using Contact.Application.Interfaces;
using Contact.Infrastructure.Data;
using Contact.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Infrastructure
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration _configuration)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserContactService, UserContactService>();
            services.AddSingleton<IUserContactService,UserContactService>();
            services.AddSingleton<ILoggerService, LoggerService>();


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(_configuration["Database:Connection"], ServerVersion.AutoDetect(_configuration["Database:Connection"]), (options) =>
                {
                    options.MigrationsAssembly("Contact.Infrastructure");
                });
            });
            return services;
        }
    }
}