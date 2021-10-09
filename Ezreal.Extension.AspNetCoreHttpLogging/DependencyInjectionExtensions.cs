using System;
using Ezreal.Extension.AspNetCoreHttpLogging;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddEzrealHttpLogging(this IServiceCollection services) =>
           services.AddEzrealHttpLogging();
        public static IServiceCollection AddEzrealHttpLogging(this IServiceCollection services, Action<HttpLoggingOptions> configureOptions) =>
          services.AddEzrealHttpLogging(null, configureOptions);
        public static IServiceCollection AddEzrealHttpLogging(this IServiceCollection services, IConfiguration configuration, Action<HttpLoggingOptions> configureOptions)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            configureOptions ??= delegate { };
            if (configuration is null)
            {
                services.Configure(configureOptions);
            }
            else
            {
                services.AddOptions<HttpLoggingOptions>().Bind(configuration).Configure(configureOptions);
            }
            return services;
        }

    }
}
