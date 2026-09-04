using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Vercel.HttpClients.Abstract;
using Soenneker.Vercel.OpenApiClientUtil.Abstract;
using Soenneker.Vercel.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Vercel.OpenApiClientUtil;

/// <inheritdoc cref="IVercelOpenApiClientUtil" />
public sealed class VercelOpenApiClientUtil : IVercelOpenApiClientUtil
{
    private readonly AsyncSingleton<VercelOpenApiClient> _client;

    public VercelOpenApiClientUtil(IVercelOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<VercelOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new VercelOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<VercelOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
