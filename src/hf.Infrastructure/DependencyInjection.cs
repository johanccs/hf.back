using hf.Domain.Abstractions;
using hf.Infrastructure.Context;
using hf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hf.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config) 
        {
            var connString = config.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentException(nameof(config));

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connString);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork>(
                sp=>sp.GetRequiredService<AppDbContext>());

            return services;

        }
    }
}
