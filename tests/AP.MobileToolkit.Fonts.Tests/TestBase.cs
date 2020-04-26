using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public abstract class TestBase
    {
        protected ITestOutputHelper TestOutputHelper { get; }

        public TestBase(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;
#if !DISABLE_FORMS_INIT
            Xamarin.Forms.Mocks.MockForms.Init();
#endif
        }
    }
}
