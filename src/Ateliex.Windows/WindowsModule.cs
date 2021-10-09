using Ateliex.Modules.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Modules.Cadastro.Modelos.ConsultaDeModelos;
using Ateliex.Modules.Decisoes.Comerciais.ConsultaDePlanosComerciais;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class WindowsModule
    {
        public static IServiceCollection AddWindows(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<ModelosWindow>();

            services.AddSingleton<ConsultaDeModelosWindow>();

            services.AddSingleton<ModeloWindow>();

            services.AddSingleton<PlanosComerciaisWindow>();

            return services;
        }
    }
}
