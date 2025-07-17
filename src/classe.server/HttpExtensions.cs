using ClassE.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassE
{
    public static class HttpExtensions
    {
        internal static IServiceCollection ConfigureJson(this IServiceCollection services)
        {
            services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opts =>
            {
                opts.SerializerOptions.Converters.Clear();
                opts.SerializerOptions.Converters.Add(new BetterEnumConvertorFactory());
                opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            return services;
        }
    }
}