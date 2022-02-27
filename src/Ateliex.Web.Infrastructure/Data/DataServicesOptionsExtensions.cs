using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ateliex.Data
{
    public static class DataServicesOptionsExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, Action<DataServicesOptionsBuilder>? optionAction = null)
        {
            var optionsBuilder = new DataServicesOptionsBuilder(services);

            optionAction?.Invoke(optionsBuilder);

            return services;
        }
    }

    public class DataServicesOptions
    {

    }

    public class DataServicesOptionsBuilder
    {
        public IServiceCollection Services { get; }

        public DataServicesOptionsBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
