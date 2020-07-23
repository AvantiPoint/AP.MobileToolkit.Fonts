using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    public class MockFont : GeneratedFont
    {
        public static MockFont Font => new MockFont();

        public MockFont()
        {
            Alias = "test";
            FontFileName = "test-font.ttf";
            Prefix = "test";
            _mappings = new Dictionary<string, string>
            {
                { "foo", "\uf024" },
                { "foo-bar", "\uf025" },
            };
        }
    }
}
