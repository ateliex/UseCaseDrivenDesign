using Ateliex.Cadastro.Modelos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class HttpModule
    {
        private static IConfiguration configuration;

        internal static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            HttpModule.configuration = configuration;

            //

            services.AddSingleton<ModelosHttpService>();

            //

            return services;
        }
    }
}
