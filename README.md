[![](https://img.shields.io/nuget/v/soenneker.semantickernel.pool.mistral.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.pool.mistral/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.pool.mistral/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.pool.mistral/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.semantickernel.pool.mistral.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker/soenneker.semantickernel.pool.mistral/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.pool.mistral/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.pool.mistral/actions/workflows/codeql.yml)

# Soenneker.SemanticKernel.Pool.Mistral

Mistral connector registration helpers for `Soenneker.SemanticKernel.Pool`.

## Installation

```bash
dotnet add package Soenneker.SemanticKernel.Pool.Mistral
```

## Add a Mistral entry

Resolve the pool and HTTP client cache from dependency injection, then register a chat or embedding entry:

```csharp
using Soenneker.SemanticKernel.Enums.KernelType;
using Soenneker.SemanticKernel.Pool.Mistral;

await pool.AddMistral(
    poolId: "chat",
    key: "mistral-primary",
    type: KernelType.Chat,
    modelId: "mistral-model-id",
    apiKey: configuration["Mistral:ApiKey"]!,
    endpoint: "https://api.mistral.ai",
    httpClientCache: httpClientCache,
    rps: 2,
    rpm: 60,
    rpd: 1_000,
    tokensPerDay: null,
    cancellationToken);
```

Use `KernelType.Chat` for Mistral chat completion or `KernelType.Embedding` for the Mistral embedding generator. Other kernel types throw `NotSupportedException` when the pool first constructs the kernel.

The adapter caches chat HTTP clients under `mistral:{poolId}:{key}` with a five-minute timeout. The `endpoint` argument is retained in the entry's `SemanticKernelOptions`, but this adapter does not pass it to the Mistral connector; connector endpoint behavior therefore comes from the Mistral Semantic Kernel package.

Pool quota values are reservations made when `GetAvailable` selects the entry. `tokensPerDay` counts one unit per acquisition; it is not populated from provider token usage.

## Remove the entry

Use the matching helper so both the pool entry and its cached HTTP client are removed:

```csharp
await pool.RemoveMistral(
    "chat",
    "mistral-primary",
    httpClientCache,
    cancellationToken);
```

Keep the API key in a protected configuration provider and avoid logging or serializing the generated `SemanticKernelOptions`.
