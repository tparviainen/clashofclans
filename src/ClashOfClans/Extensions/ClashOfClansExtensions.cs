using ClashOfClans;
using ClashOfClans.Core;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClashOfClansExtensions
    {
        public static IServiceCollection AddClashOfClans(this IServiceCollection services, Action<ClashOfClansOptions> configureOptions)
        {
            services.AddOptions();
            services.Configure(configureOptions);

            services.AddSingleton<IClashOfClans, ClashOfClansClient>();

            return services;
        }
    }
}
