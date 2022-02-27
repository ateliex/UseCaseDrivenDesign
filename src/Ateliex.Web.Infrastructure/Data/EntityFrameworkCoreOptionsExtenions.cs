using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Decisoes.Comerciais;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ateliex.Data
{
    public static class EntityFrameworkCoreOptionsExtenions
    {
        public static DataServicesOptionsBuilder UseEntityFrameworkCore(this DataServicesOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            optionsBuilder.Services.AddDbContext<AteliexDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //

            optionsBuilder.Services.AddTransient<IConsultaDeModelos, ModelosDbService>();

            optionsBuilder.Services.AddTransient<IRepositorioDeModelos, ModelosDbService>();

            //

            optionsBuilder.Services.AddTransient<IConsultaDePlanosComerciais, PlanosComerciaisDbService>();

            optionsBuilder.Services.AddTransient<IRepositorioDePlanosComerciais, PlanosComerciaisDbService>();

            return optionsBuilder;
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
