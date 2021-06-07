using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class DevIconsTests : FontTestBase
    {
        protected override IFont Font => DevIcons.Font;

        protected override string FileName => "devicons.ttf";
        protected override string Alias => "devicons";

        [Theory]
        [InlineData(Mappings.DevIcons.Android)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.DevIcons.Android, "\ue60e")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
