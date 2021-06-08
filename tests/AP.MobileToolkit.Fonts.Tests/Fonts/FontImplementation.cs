using System;
using Xunit;

namespace AP.MobileToolkit.Fonts.Tests.Fonts
{
    public sealed class FontImplementation : IDisposable
    {
        public FontImplementation()
        {
            FontRegistry.Clear();
            Xamarin.Forms.Mocks.MockForms.Init();
            FontRegistry.RegisterFonts(
                DevIcons.Font,
                FontAwesomeBrands.Font,
                FontAwesomeRegular.Font,
                FontAwesomeSolid.Font,
                MaterialIcons.Font,
                MaterialIconsOutlined.Font,
                MaterialIconsRound.Font,
                MaterialIconsSharp.Font);
        }

        public void Dispose()
        {
            FontRegistry.Clear();
        }
    }

    [CollectionDefinition(nameof(FontImplementation))]
    public class FontImplementationCollection : ICollectionFixture<FontImplementation>
    {
    }
}
