namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    public class SampleFontAwesomeSolid : EmbeddedWebFont
    {
        private SampleFontAwesomeSolid()
            : base(FontFile, FontAlias, CssFileName, typeof(SampleFontAwesomeRegular))
        {
        }

        public const string FontFile = "FontAwesomeSolid";
        public const string FontAlias = "FAS";
        private const string CssFileName = "fontawesome.min.css";

        public static IFont Font { get; } = new SampleFontAwesomeSolid();
    }
}
