using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class FontAwesomeSolidTests : FontTestBase
    {
        protected override IFont Font => FontAwesomeSolid.Font;

        protected override string FileName => "fa-solid-900.ttf";
        protected override string Alias => "fas";

        [Theory]
        [InlineData(Mappings.FontAwesomeSolid.User)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.FontAwesomeSolid.User, "\uf007")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
