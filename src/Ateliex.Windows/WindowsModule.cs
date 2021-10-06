using Ateliex.Modulos.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Modulos.Cadastro.Modelos.ConsultaDeModelos;
using Ateliex.Modulos.Decisoes.Comerciais.ConsultaDePlanosComerciais;
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
