using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AP.MobileToolkit.Fonts.Tests.Mocks;
using Xamarin.Forms;
using Xunit;
using Xunit.Abstractions;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class BindableIconNameTests : TestBase
    {
        public BindableIconNameTests(ITestOutputHelper testOutputHelper, FontRegistrySetup setup)
            : base(testOutputHelper, setup)
        {
        }

        [Fact]
        public void NoBindingContext_HasNoElements()
        {
            var page = new Page1();
            Assert.Empty(page.MainLayout.Children);
        }

        [Fact]
        public void WhenBindingContextIsSet_HasTwoChildren()
        {
            var page = new Page1
            {
                BindingContext = new Page1ViewModel()
            };

            Assert.Equal(2, page.MainLayout.Children.Count);
        }

        [Theory]
        [InlineData(0, "\uf024")]
        [InlineData(1, "\uf025")]
        public void TextPropertyIsSet(int index, string glyph)
        {
            var page = new Page1
            {
                BindingContext = new Page1ViewModel()
            };

            var label = page.MainLayout.Children.ElementAt(index) as Label;
            Assert.NotNull(label);
            Assert.Equal(glyph, label.Text);
            Assert.Equal(MockFont.Font.FontFileName, label.FontFamily);
        }
    }
}
