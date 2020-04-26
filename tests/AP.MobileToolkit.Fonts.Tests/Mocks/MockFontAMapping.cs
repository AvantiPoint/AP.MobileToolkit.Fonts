using System;
using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    class MockFontAMapping
    {
        public const string Foo = "\uf024";

        public const string FooBar = "\uf025";
    }

    public class MockFontA : EmbeddedMappedFont
    {
        public MockFontA()
            : base(FontFile, FontAlias, typeof(MockFontAMapping))
        {
        }

        public const string FontFile = "TestFont";
        public const string FontAlias = "test";
    }
}
