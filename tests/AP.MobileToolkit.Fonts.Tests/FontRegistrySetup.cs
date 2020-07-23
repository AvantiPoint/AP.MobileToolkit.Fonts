using System;
using AP.MobileToolkit.Fonts.Tests.Mocks;

namespace AP.MobileToolkit.Fonts.Tests
{
    public sealed class FontRegistrySetup : IDisposable
    {
        public FontRegistrySetup()
        {
            FontRegistry.Clear();
            Xamarin.Forms.Mocks.MockForms.Init();
            FontRegistry.RegisterFonts(MockFont.Font);
        }

        public void Dispose()
        {
            FontRegistry.Clear();
        }
    }
}
