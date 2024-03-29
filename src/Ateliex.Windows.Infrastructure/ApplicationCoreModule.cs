﻿using Ateliex.Modules.Cadastro.Modelos;
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

            services.AddSingleton<ICadastroDeModelos, ServicoDeCadastroDeModelos>();

            //

            return services;
        }
    }
}
