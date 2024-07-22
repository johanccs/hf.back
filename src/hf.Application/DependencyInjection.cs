using Microsoft.Extensions.DependencyInjection;

namespace hf.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                //todo: Add ValidationBehaviour
            });

            return services;
        }
    }
}
