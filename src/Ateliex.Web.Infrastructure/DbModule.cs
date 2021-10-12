using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Decisoes.Comerciais;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex
{
    public static class DbModule
    {
        private static IConfiguration configuration;

        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            DbModule.configuration = configuration;

            //

            services.AddDbContext<AteliexDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //

            services.AddTransient<IConsultaDeModelos, ModelosDbService>();

            services.AddTransient<IRepositorioDeModelos, ModelosDbService>();

            //

            services.AddTransient<IConsultaDePlanosComerciais, PlanosComerciaisDbService>();

            services.AddTransient<IRepositorioDePlanosComerciais, PlanosComerciaisDbService>();

            //

            return services;
        }

        public static void EnsureDatabaseCreatedAsync(IServiceScopeFactory serviceScopeFactory)
        {
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AteliexDbContext>();

                dbContext.Database.EnsureDeleted();

                dbContext.Database.EnsureCreated();

                //dbContext.Database.Migrate();
            }
        }
    }
}
