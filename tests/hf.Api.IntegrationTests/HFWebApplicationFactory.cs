using hf.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace hf.Api.IntegrationTests
{
    public class HFWebApplicationFactory:WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //Inject password from usersecrets or through ci/cd pipelines variables
            var connString = "Server=localhost;Database=hf_tests;User Id=sa;Password=password123;Max Pool size=100;TrustServerCertificate=True";

            builder.ConfigureTestServices(services => {
                services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
                services.AddSqlServer<AppDbContext>(connString);

                var dbContext = CreateDbContext(services);

                dbContext.Database.EnsureDeleted();
            });
        }

        private static AppDbContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            return dbContext;
        }
    }
}
