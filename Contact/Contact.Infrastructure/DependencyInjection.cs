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
                options.UseSqlServer(_configuration["Database:Connection"],x=>x.MigrationsAssembly("Contact.Infrastructure"));

            });
            return services;
        }
    }
}