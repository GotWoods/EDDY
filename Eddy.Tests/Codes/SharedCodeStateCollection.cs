using Xunit;

namespace Eddy.Tests.Codes;

/// <summary>
/// <see cref="Eddy.Core.Codes.CodeList.Catalog"/> and <see cref="Eddy.Core.Validation.ValidationSettings"/>
/// are process-wide static state. Every test that swaps either one restores it in a finally block, but
/// xUnit runs different test classes in parallel by default, so two such tests could still race each
/// other mid-swap. Putting them all in this collection serialises them relative to one another.
/// </summary>
[CollectionDefinition("CodeCatalog", DisableParallelization = true)]
public class SharedCodeStateCollection
{
}
