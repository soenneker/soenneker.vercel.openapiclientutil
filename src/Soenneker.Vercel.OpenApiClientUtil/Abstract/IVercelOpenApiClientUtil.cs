using Soenneker.Vercel.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Vercel.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IVercelOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<VercelOpenApiClient> Get(CancellationToken cancellationToken = default);
}
