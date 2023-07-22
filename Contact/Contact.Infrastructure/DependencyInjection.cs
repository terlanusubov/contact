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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserContactService, UserContactService>();
            services.AddScoped<IUserContactService, UserContactService>();
            services.AddScoped<ILoggerService, LoggerService>();

            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IAccountService, AccountService>();

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