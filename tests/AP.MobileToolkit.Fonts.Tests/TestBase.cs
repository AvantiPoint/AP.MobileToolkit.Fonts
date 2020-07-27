using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    [Collection(nameof(RegistryTests))]
    public abstract class TestBase : IClassFixture<FontRegistrySetup>
    {
        protected ITestOutputHelper TestOutputHelper { get; }
        protected FontRegistrySetup Setup { get; }

        protected TestBase(ITestOutputHelper testOutputHelper, FontRegistrySetup setup)
        {
            TestOutputHelper = testOutputHelper;
            Setup = setup;
#if !DISABLE_FORMS_INIT
            Xamarin.Forms.Mocks.MockForms.Init();
#endif
        }
    }
}
