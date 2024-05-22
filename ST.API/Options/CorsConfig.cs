using Microsoft.Extensions.DependencyInjection;

namespace ST.API.Options;

public static class CorsConfig
{
    public static void AddCorsConfig(this IServiceCollection service)
    {
        service.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
            }));
    }
}