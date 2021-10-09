using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Decisoes.Vendas;
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
            
            services.AddTransient<CalculoDeTaxaDeMarcacao, ServicoDeCalculoDeTaxaDeMarcacao>();
            
            services.AddTransient<CalculadoraDeTaxaDeMarcacao>();

            //

            return services;
        }
    }
}
