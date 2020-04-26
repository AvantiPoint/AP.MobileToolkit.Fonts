using System;
using System.Collections.Generic;
using System.Text;
using AP.MobileToolkit.Fonts.Tests.Mocks;

namespace AP.MobileToolkit.Fonts.Tests
{
    public class FontRegistrySetup : IDisposable
    {
        public FontRegistrySetup()
        {
            FontRegistry.Clear();
            Xamarin.Forms.Mocks.MockForms.Init();
            FontRegistry.RegisterFonts(new MockFontA());
        }

        public void Dispose()
        {
            FontRegistry.Clear();
        }
    }
}
