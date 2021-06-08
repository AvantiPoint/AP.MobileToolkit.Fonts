using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class FontAwesomeBrandsTests : FontTestBase
    {
        protected override IFont Font => FontAwesomeBrands.Font;

        protected override string FileName => "fa-brands-400.ttf";
        protected override string Alias => "fab";

        [Theory]
        [InlineData(Mappings.FontAwesomeBrands.Git)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.FontAwesomeBrands.Git, "\uf1d3")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
