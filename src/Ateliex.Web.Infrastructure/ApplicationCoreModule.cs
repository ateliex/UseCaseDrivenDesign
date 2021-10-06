using Ateliex.Modulos.Cadastro.Modelos.CadastroDeModelos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class ApplicationCoreModule
    {
        private static IConfiguration configuration;

        public static IServiceCollection AddApplicationCore(this IServiceCollection services, IConfiguration configuration)
        {
            ApplicationCoreModule.configuration = configuration;

            //

            services.AddTransient<ICadastroDeModelos, ServicoDeCadastroDeModelos>();

            //

            return services;
        }
    }
}
