using System;
using System.Linq;
using Xamarin.Forms;
using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    [Collection(nameof(FontImplementation))]
    public abstract class FontTestBase
    {
        protected abstract string FileName { get; }
        protected abstract string Alias { get; }
        protected abstract IFont Font { get; }

        [Fact]
        public void HasCorrectAlias()
        {
            Assert.Equal(Alias, Font.Alias);
        }

        [Fact]
        public void HasCorrectFontFile()
        {
            Assert.Equal(FileName, Font.FontFileName);
        }

        [Fact]
        public void HasEmbeddedFont()
        {
            var assembly = Font.GetType().Assembly;
            Assert.Single(assembly.GetManifestResourceNames());

            var resourceId = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(Font.FontFileName));

            Assert.False(string.IsNullOrEmpty(resourceId));
        }

        protected void MapsToGlyphInternal(string mapping, string expectedGlyph)
        {
            var font = FontRegistry.LocateFont(mapping);
            var glyph = font.GetGlyph(mapping);

            Assert.Equal(expectedGlyph, glyph);

            var parts = mapping.Split(' ');
            Assert.Equal(2, parts.Length);

            var glyph2 = font.GetGlyph(parts[1]);
            Assert.Equal(glyph, glyph2);
        }

        protected void ReturnsCorrectFontInternal(string selector)
        {
            var expectedFont = Font;
            var font = FontRegistry.LocateFont(selector);

            Assert.Equal(expectedFont.Alias, font.Alias);
            Assert.Equal(expectedFont.FontFileName, font.FontFileName);
            Assert.Equal(expectedFont.GetGlyph(selector), font.GetGlyph(selector));
        }

        public void Dispose()
        {
            FontRegistry.Clear();
        }
    }
}
