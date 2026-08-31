[![](https://img.shields.io/nuget/v/soenneker.vercel.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.vercel.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.vercel.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.openapiclientutil/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.vercel.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Vercel.OpenApiClientUtil

Provides a cached `VercelOpenApiClient` backed by an authenticated Vercel HTTP client.

## Installation

```bash
dotnet add package Soenneker.Vercel.OpenApiClientUtil
```

## Configuration

```json
{
  "Vercel": {
    "AccessToken": "your-vercel-access-token"
  }
}
```

`Vercel:ApiKey` remains supported as a legacy name for the access token. The token must be scoped to the personal account or team being accessed.

## Registration

```csharp
using Soenneker.Vercel.OpenApiClientUtil.Registrars;

services.AddVercelOpenApiClientUtilAsScoped();
```

Use `AddVercelOpenApiClientUtilAsSingleton()` to share the generated-client wrapper too. Both registrations borrow the singleton Vercel HTTP provider; disposing a scoped wrapper does not remove or dispose that shared transport.

## Usage

```csharp
using Soenneker.Vercel.OpenApiClient;
using Soenneker.Vercel.OpenApiClient.Models;
using Soenneker.Vercel.OpenApiClientUtil.Abstract;

public sealed class DeploymentFilesReader
{
    private readonly IVercelOpenApiClientUtil _clients;

    public DeploymentFilesReader(IVercelOpenApiClientUtil clients)
    {
        _clients = clients;
    }

    public async ValueTask<List<FileTree>?> Get(
        string deploymentId,
        string? teamId,
        CancellationToken cancellationToken)
    {
        VercelOpenApiClient client = await _clients.Get(cancellationToken);

        return await client.V6.Deployments[deploymentId].Files.GetAsync(
            request => request.QueryParameters.TeamId = teamId,
            cancellationToken);
    }
}
```

Omit `teamId` for resources in the token owner's personal account. Vercel and transport failures propagate through Kiota exceptions.
