using ClashOfClans;
using ClashOfClans.Api;
using ClashOfClans.Core;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClashOfClansExtensions
    {
        public static IServiceCollection AddClashOfClans(this IServiceCollection services,
                                                         Action<ClashOfClansOptionsV2> configureOptions)
        {
            services.AddOptions();
            services.Configure(configureOptions);

            var options = new ClashOfClansOptionsV2();
            configureOptions(options);
            TokenValidator.Validate(options.Tokens);

            // Services
            services.AddSingleton(services =>
            {
                return new ClashOfClansOptionsInternal(options.Tokens)
                {
                    MaxRequestsPerSecond = options.MaxRequestsPerSecond
                };
            });

            services.AddSingleton<IGameData, GameData>();

            // Fine grained public interfaces
            services.AddSingleton<IClans, Clans>();
            services.AddSingleton<ILocations, Locations>();
            services.AddSingleton<ILeagues, Leagues>();
            services.AddSingleton<IPlayers, Players>();
            services.AddSingleton<ILabels, Labels>();
            services.AddSingleton<IGoldPass, GoldPass>();

            // "the" API that depends on fine grained interfaces
            services.AddSingleton<IClashOfClans, ClashOfClansClient>();

            return services;
        }
    }
}
