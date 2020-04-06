using Ateliex.Cadastro.Modelos;
using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Transactions;

namespace Ateliex
{
    public static class InfrastructureModule
    {
        private static IConfiguration configuration;

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            InfrastructureModule.configuration = configuration;

            //

            //services.AddSingleton<IUnitOfWork, TransactionScopeManager>();
            
            services.AddSingleton<IUnitOfWork, DummyTransactionManager>();

            //

            services.AddSingleton<IConsultaDeModelos, ModelosInfraService>();

            services.AddSingleton<IRepositorioDeModelos, ModelosInfraService>();

            //

            //services.AddSingleton<IConsultaDePlanosComerciais, PlanosComerciaisInfraService>();

            //services.AddSingleton<IRepositorioDePlanosComerciais, PlanosComerciaisInfraService>();

            //

            services.AddApplicationCore(configuration);

            services.AddDbServices(configuration);

            services.AddHttpServices(configuration);

            //

            return services;
        }
    }
}
