using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class FontAwesomeRegularTests : FontTestBase
    {
        protected override IFont Font => FontAwesomeRegular.Font;

        protected override string FileName => "fa-regular-400.ttf";
        protected override string Alias => "far";

        [Theory]
        [InlineData(Mappings.FontAwesomeRegular.User)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.FontAwesomeRegular.User, "\uf007")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
