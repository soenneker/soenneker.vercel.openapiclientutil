using Soenneker.Vercel.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Vercel.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class VercelOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IVercelOpenApiClientUtil _openapiclientutil;

    public VercelOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IVercelOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
