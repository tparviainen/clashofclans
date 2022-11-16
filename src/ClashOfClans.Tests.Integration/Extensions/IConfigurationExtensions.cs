using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.Configuration;

internal static class IConfigurationExtensions
{
    /// <summary>
    /// Gets a configuration value or throws if value is null
    /// </summary>
    public static string GetValue(this IConfiguration configuration, string key) =>
        configuration[key] ?? throw new NullReferenceException();

    /// <summary>
    /// Gets a configuration values or throws if value is null
    /// </summary>
    public static IEnumerable<string> GetValues(this IConfiguration configuration, string key) =>
        configuration.GetSection(key).GetChildren().Select(x => x.Value ?? throw new NullReferenceException());

}
