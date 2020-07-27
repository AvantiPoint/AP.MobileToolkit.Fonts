using AP.MobileToolkit.Markup;
using Xamarin.Forms;
using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class CsharpMarkupTests : TestBase, IClassFixture<FontRegistrySetup>
    {
        public CsharpMarkupTests(ITestOutputHelper testOutputHelper, FontRegistrySetup setup)
            : base(testOutputHelper, setup)
        {
            FontRegistry.Clear();
            FontRegistry.RegisterFonts(FontAwesomeRegular.Font, FontAwesomeSolid.Font);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnLabel()
        {
            var label = new Label().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(FontAwesomeRegular.Font.FontFileName, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnSpan()
        {
            var label = new Span().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(FontAwesomeRegular.Font.FontFileName, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnEditor()
        {
            var label = new Editor().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(FontAwesomeRegular.Font.FontFileName, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnButton()
        {
            var label = new Button().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(FontAwesomeRegular.Font.FontFileName, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnSearchBar()
        {
            var label = new SearchBar().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(FontAwesomeRegular.Font.FontFileName, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }
    }
}
