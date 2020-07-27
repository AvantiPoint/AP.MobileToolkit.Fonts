using Xunit;

namespace AP.MobileToolkit.Fonts.Tests
{
    [CollectionDefinition(nameof(RegistryTests), DisableParallelization = true)]
    public class RegistryTestCollection : ICollectionFixture<RegistryTests>
    {
    }
}
