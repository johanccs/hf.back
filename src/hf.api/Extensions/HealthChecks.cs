using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace hf.Api.Extensions
{
    public static class HealthChecks
    {
        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    configuration.GetConnectionString("DefaultConnection")!,
                    healthQuery:"Select 1", name:"SQL Server", failureStatus:HealthStatus.Unhealthy,
                    tags: new[] {"Feedback", "Database"});

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10);
                opt.MaximumHistoryEntriesPerEndpoint(60);
                opt.SetApiMaxActiveRequests(5);
                opt.AddHealthCheckEndpoint("feedback api", "api/health");
            });
        }

    }
}
