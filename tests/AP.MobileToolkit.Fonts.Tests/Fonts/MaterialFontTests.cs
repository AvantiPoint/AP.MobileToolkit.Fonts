using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class MaterialFontTests : FontTestBase
    {
        protected override IFont Font => MaterialIcons.Font;

        protected override string FileName => "MaterialIcons-Regular.ttf";
        protected override string Alias => "material";

        [Theory]
        [InlineData(Mappings.MaterialIcons.Android)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.MaterialIcons.Android, "\ue859")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
