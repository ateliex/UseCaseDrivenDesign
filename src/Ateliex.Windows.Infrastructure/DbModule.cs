using Ateliex.Modulos.Cadastro.Modelos;
using Ateliex.Modulos.Decisoes.Comerciais;
using Ateliex.Modulos.Decisoes.Comerciais.ConsultaDePlanosComerciais;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class DbModule
    {
        private static IConfiguration configuration;

        internal static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            DbModule.configuration = configuration;

            //

            services.AddDbContext<AteliexDbContext>(options =>
                options.UseSqlite(@"Data Source=Ateliex.db"), ServiceLifetime.Singleton);

            //

            //services.AddSingleton<IUnitOfWork, AteliexDbContext>();

            //

            services.AddSingleton<ModelosDbService>();

            //

            services.AddSingleton<IConsultaDePlanosComerciais, PlanosComerciaisDbService>();

            services.AddSingleton<IRepositorioDePlanosComerciais, PlanosComerciaisDbService>();

            //

            return services;
        }

        public static void EnsureDatabaseCreatedAsync(IServiceScopeFactory serviceScopeFactory)
        {
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AteliexDbContext>();

                dbContext.Database.EnsureCreated();

                dbContext.Database.Migrate();
            }
        }
    }
}
