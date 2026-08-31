using Soenneker.Vercel.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Vercel.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Vercel OpenAPI client backed by authenticated transport.
/// </summary>
public interface IVercelOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The token used to cancel client creation.</param>
    /// <returns>The cached client.</returns>
    ValueTask<VercelOpenApiClient> Get(CancellationToken cancellationToken = default);
}
