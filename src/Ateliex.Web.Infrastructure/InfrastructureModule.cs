using Ateliex.Data;
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

            services.AddTransient<IUnitOfWork, TransactionScopeManager>();

            //

            services.AddApplicationCore(configuration);

            //

            return services
                .AddDataServices(options =>
                    options.UseEntityFrameworkCore(configuration));
        }
    }
}
