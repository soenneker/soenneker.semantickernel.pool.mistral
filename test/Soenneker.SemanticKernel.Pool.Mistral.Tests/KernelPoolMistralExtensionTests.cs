using Soenneker.Tests.HostedUnit;

namespace Soenneker.SemanticKernel.Pool.Mistral.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class KernelPoolMistralExtensionTests : HostedUnitTest
{

    public KernelPoolMistralExtensionTests(Host host) : base(host)
    {

    }

    [Test]
    public void Default()
    {

    }
}
