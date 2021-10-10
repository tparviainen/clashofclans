using ClashOfClans;
using ClashOfClans.Api;
using ClashOfClans.Core;
using ClashOfClans.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Clash of Clans services to the service collection. The registered services are the main
        /// interface <see cref="IClashOfClans"/> and the individual interfaces <see cref="IClans"/>,
        /// <see cref="ILocations"/>, <see cref="ILeagues"/>, <see cref="IPlayers"/>, <see cref="ILabels"/>
        /// and <see cref="IGoldPass"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="configureOptions">An <see cref="Action"/> to configure the provided <see cref="ClashOfClansOptionsV2"/></param>
        /// <returns></returns>
        public static IServiceCollection AddClashOfClans(this IServiceCollection services,
                                                         Action<ClashOfClansOptionsV2> configureOptions)
        {
            services.AddOptions();
            services.Configure(configureOptions);

            // Services
            services.AddScoped(services =>
            {
                var options = new ClashOfClansOptionsV2();
                configureOptions(options);
                TokenValidator.Validate(options.Tokens);

                return new ClashOfClansOptionsInternal(options.Tokens)
                {
                    MaxRequestsPerSecond = options.MaxRequestsPerSecond
                };
            });

            services.AddScoped<IGameData, GameData>();

            // Fine grained public interfaces
            services.AddScoped<IClans, Clans>();
            services.AddScoped<ILocations, Locations>();
            services.AddScoped<ILeagues, Leagues>();
            services.AddScoped<IPlayers, Players>();
            services.AddScoped<ILabels, Labels>();
            services.AddScoped<IGoldPass, GoldPass>();

            // "the" API that depends on fine grained interfaces
            services.AddScoped<IClashOfClans, ClashOfClansDIClient>();

            return services;
        }
    }
}
