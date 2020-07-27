using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts.Tests.Mocks;
using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class IconSpanTests : TestBase, IClassFixture<FontRegistrySetup>
    {
        public IconSpanTests(ITestOutputHelper testOutputHelper, FontRegistrySetup setup)
            : base(testOutputHelper, setup)
        {
        }

        [Fact]
        public void TextIsSetFromIconName()
        {
            var span = new IconSpan { GlyphName = "test-foo" };

            Assert.Single(span.Text);
            Assert.Equal(MockFontAMapping.Foo, span.Text);
        }
    }
}
