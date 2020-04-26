namespace AP.MobileToolkit.Fonts
{
    public abstract class FontBase : IFont
    {
        protected FontBase(string fontFileName, string alias)
        {
            FontFileName = fontFileName;
            Alias = alias;
        }

        public string Alias { get; }
        public string FontFileName { get; }

        public abstract string GetGlyph(string name);
    }
}
