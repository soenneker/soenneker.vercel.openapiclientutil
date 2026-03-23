using Soenneker.Vercel.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Vercel.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class VercelOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IVercelOpenApiClientUtil _openapiclientutil;

    public VercelOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IVercelOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
