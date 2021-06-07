using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public class MaterialIconsSharpTests : FontTestBase
    {
        protected override IFont Font => MaterialIconsSharp.Font;

        protected override string FileName => "MaterialIconsSharp-Regular.otf";
        protected override string Alias => "material-sharp";

        [Theory]
        [InlineData(Mappings.MaterialIconsSharp.Android)]
        public void ReturnsCorrectFont(string selector)
        {
            ReturnsCorrectFontInternal(selector);
        }

        [Theory]
        [InlineData(Mappings.MaterialIconsSharp.Android, "\ue859")]
        public void MapsToGlyph(string mapping, string expectedGlyph)
        {
            MapsToGlyphInternal(mapping, expectedGlyph);
        }
    }
}
