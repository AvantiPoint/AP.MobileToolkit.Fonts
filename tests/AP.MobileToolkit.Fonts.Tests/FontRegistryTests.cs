using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Fonts.Tests.Mocks;
using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class FontRegistryTests : TestBase
    {
        private const string FontAlias = "test";
        private const string FontFamily = "TestFontFamily";

        public FontRegistryTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void FontRegistryDoesNotThrowException()
        {
            var ex = Record.Exception(() => RegisterTestIcons());
            Assert.Null(ex);
        }

        [Fact]
        public void TestFontIsRegistered()
        {
            RegisterTestIcons();

            Assert.Single(FontRegistry.RegisteredFonts);

            var iconFont = FontRegistry.RegisteredFonts.First().Value;

            Assert.Equal(FontFamily, iconFont.FontFileName);
            Assert.Equal(FontAlias, iconFont.Alias);
            Assert.IsType<EmbeddedMappedFont>(iconFont);
            var font = (EmbeddedMappedFont)iconFont;
            Assert.Equal(2, font._mappings.Count());
        }

        [Theory]
        [InlineData("test-foo", MockFontAMapping.Foo)]
        [InlineData("test-foo-bar", MockFontAMapping.FooBar)]

        public void RegistryReturnsExpectedChar(string icon, string expectedGlyph)
        {
            RegisterTestIcons();

            Assert.True(FontRegistry.HasFont(icon, out var font));
            var glyph = font.GetGlyph(icon);
            Assert.False(string.IsNullOrEmpty(glyph));
            Assert.Equal(expectedGlyph, glyph);
        }

        private void RegisterTestIcons()
        {
            FontRegistry.Clear();
            FontRegistry.RegisterFonts(new EmbeddedMappedFont("TestFontFamily", "test", typeof(MockFontAMapping)));
        }
    }
}
