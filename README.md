[![](https://img.shields.io/nuget/v/soenneker.semantickernel.pool.mistral.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.pool.mistral/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.pool.mistral/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.pool.mistral/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.semantickernel.pool.mistral.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.semantickernel.pool.mistral/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.semantickernel.pool.mistral/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.semantickernel.pool.mistral/actions/workflows/codeql.yml)

# Soenneker.SemanticKernel.Pool.Mistral

Provides Mistral-specific registration extensions for KernelPoolManager, enabling integration via Semantic Kernel.

## Install

```bash
dotnet add package Soenneker.SemanticKernel.Pool.Mistral
```

## Quick start

```csharp
using Soenneker.SemanticKernel.Pool.Mistral;

ISemanticKernelPool pool = /* obtain from your application */;
await pool.AddMistral("value", "value", /* supply type */ default!, "value", "value", "value", /* supply httpClientCache */ default!, 1, 1, 1, default);
```

Registers a Mistral model in the kernel pool with optional rate and token limits.

## What you get

- `KernelPoolMistralExtension` — Provides Mistral-specific registration extensions for KernelPoolManager, enabling integration via Semantic Kernel.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `KernelPoolMistralExtension.AddMistral(pool, poolId, key, type, modelId, apiKey, endpoint, httpClientCache, rps, rpm, rpd, tokensPerDay, cancellationToken)` | Registers a Mistral model in the kernel pool with optional rate and token limits. | A `ValueTask` representing the asynchronous registration operation. |
| `KernelPoolMistralExtension.RemoveMistral(pool, poolId, key, httpClientCache, cancellationToken)` | Unregisters a Mistral model from the kernel pool and removes associated HTTP client and kernel cache entries. | A `ValueTask` representing the asynchronous unregistration operation. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
