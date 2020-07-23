using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class FontTests
    {
        private ITestOutputHelper testOutput;

        public FontTests(ITestOutputHelper testOutputHelper)
        {
            testOutput = testOutputHelper;
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Theory]
        [InlineData("fa-laugh-squint", "\uf59b")]
        [InlineData("fa-address-card", "\uf2bb")]
        [InlineData("fa-comment-dots", "\uf4ad")]
        public void LookupByClassSelector(string selector, string glyph)
        {
            var font = FontAwesomeRegular.Font;
            var resolvedGlyph = font.GetGlyph(selector);

            Assert.NotNull(resolvedGlyph);
            Assert.Single(resolvedGlyph);
            Assert.Equal(glyph, resolvedGlyph);
        }

        [Theory]
        [InlineData("fab fa-laugh-squint", "\uf59b")]
        [InlineData("far fa-address-card", "\uf2bb")]
        [InlineData("fab fa-comment-dots", "\uf4ad")]
        public void LookupByFullyQualifiedSelector(string selector, string glyph)
        {
            var font = FontAwesomeRegular.Font;
            var resolvedGlyph = font.GetGlyph(selector);

            Assert.NotNull(resolvedGlyph);
            Assert.Single(resolvedGlyph);
            Assert.Equal(glyph, resolvedGlyph);
        }

        object lockobject = new object();
        [Theory]
        [InlineData("far fa-calendar", "\uf133", "far")]
        [InlineData("fas fa-calendar", "\uf133", "fas")]
        public void LookupFromRegistry(string selector, string expectedGlyph, string fontAlias)
        {
            lock (lockobject)
            {
                FontRegistry.Clear();
                FontRegistry.RegisterFonts(FontAwesomeRegular.Font, FontAwesomeSolid.Font);

                var font = FontRegistry.LocateFont(selector);

                Assert.NotNull(font);

                Assert.Equal(fontAlias, font.Alias);

                var locatedGlyph = font.GetGlyph(selector);

                Assert.False(string.IsNullOrWhiteSpace(locatedGlyph));
                Assert.Equal(expectedGlyph, locatedGlyph);
            }
        }
    }
}
