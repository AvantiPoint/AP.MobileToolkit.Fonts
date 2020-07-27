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
    public class FontRegistryTests : TestBase, IClassFixture<FontRegistrySetup>
    {
        //private const string FontAlias = "test";
        //private const string FontFamily = "TestFontFamily";

        public FontRegistryTests(ITestOutputHelper testOutputHelper, FontRegistrySetup setup)
            : base(testOutputHelper, setup)
        {
        }

        [Fact]
        public void TestFontIsRegistered()
        {
            Assert.Single(FontRegistry.RegisteredFonts);

            var iconFont = FontRegistry.RegisteredFonts.First().Value;

            Assert.Equal(MockFont.Font.FontFileName, iconFont.FontFileName);
            Assert.Equal(MockFont.Font.Alias, iconFont.Alias);
            Assert.IsType<MockFont>(iconFont);
            var font = (MockFont)iconFont;
            Assert.Equal(2, font._mappings.Count());
        }

        [Theory]
        [InlineData("test-foo", MockFontAMapping.Foo)]
        [InlineData("test-foo-bar", MockFontAMapping.FooBar)]
        public void RegistryReturnsExpectedChar(string icon, string expectedGlyph)
        {
            Assert.True(FontRegistry.HasFont(icon, out var font));
            var glyph = font.GetGlyph(icon);
            Assert.False(string.IsNullOrEmpty(glyph));
            Assert.Equal(expectedGlyph, glyph);
        }
    }
}
