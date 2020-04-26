using System;
using System.Collections.Generic;
using System.Text;

namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    public class SampleFontAwesomeRegular : EmbeddedWebFont
    {
        private SampleFontAwesomeRegular()
            : base(FontFile, FontAlias, CssFileName, typeof(SampleFontAwesomeRegular))
        {
        }

        public const string FontFile = "FontAwesomeRegular";
        public const string FontAlias = "FAR";
        private const string CssFileName = "fontawesome.min.css";

        public static IFont Font { get; } = new SampleFontAwesomeRegular();
    }
}
