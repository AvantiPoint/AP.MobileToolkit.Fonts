using System;
using AP.MobileToolkit.Fonts.Tests.Mocks;
using AP.MobileToolkit.Markup;
using Xamarin.Forms;
using Xunit;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class CsharpMarkupTests
    {
        public CsharpMarkupTests()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            FontRegistry.Clear();
            FontRegistry.RegisterFonts(SampleFontAwesomeRegular.Font, SampleFontAwesomeSolid.Font);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnLabel()
        {
            var label = new Label().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(SampleFontAwesomeRegular.FontFile, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnSpan()
        {
            var label = new Span().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(SampleFontAwesomeRegular.FontFile, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnEditor()
        {
            var label = new Editor().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(SampleFontAwesomeRegular.FontFile, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnButton()
        {
            var label = new Button().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(SampleFontAwesomeRegular.FontFile, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }

        [Fact]
        public void SetIconSetsTextAndFontFamilyOnSearchBar()
        {
            var label = new SearchBar().SetIcon("far fa-calendar");

            // "far fa-calendar", "\uf133"
            Assert.Equal(SampleFontAwesomeRegular.FontFile, label.FontFamily);
            Assert.Equal("\uf133", label.Text);
        }
    }
}
