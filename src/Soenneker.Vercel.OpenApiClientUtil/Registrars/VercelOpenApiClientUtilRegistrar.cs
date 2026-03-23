using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Vercel.HttpClients.Registrars;
using Soenneker.Vercel.OpenApiClientUtil.Abstract;

namespace Soenneker.Vercel.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class VercelOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="VercelOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddVercelOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddVercelOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IVercelOpenApiClientUtil, VercelOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="VercelOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddVercelOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddVercelOpenApiHttpClientAsSingleton()
                .TryAddScoped<IVercelOpenApiClientUtil, VercelOpenApiClientUtil>();

        return services;
    }
}
