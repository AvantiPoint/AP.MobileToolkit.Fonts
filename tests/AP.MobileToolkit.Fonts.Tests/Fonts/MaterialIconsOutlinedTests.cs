using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class MaterialIconsOutlinedTests : FontTestBase
    {
        protected override IFont Font => MaterialIconsOutlined.Font;

        protected override string FileName => "MaterialIconsOutlined-Regular.otf";
        protected override string Alias => "material-outlined";

        [Theory]
        [InlineData(Mappings.MaterialIconsOutlined.Android)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.MaterialIconsOutlined.Android, "\ue859")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
