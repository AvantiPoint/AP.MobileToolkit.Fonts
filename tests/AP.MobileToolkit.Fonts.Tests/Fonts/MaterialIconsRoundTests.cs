using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class MaterialIconsRoundTests : FontTestBase
    {
        protected override IFont Font => MaterialIconsRound.Font;

        protected override string FileName => "MaterialIconsRound-Regular.otf";
        protected override string Alias => "material-round";

        [Theory]
        [InlineData(Mappings.MaterialIconsRound.Android)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.MaterialIconsRound.Android, "\ue859")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
