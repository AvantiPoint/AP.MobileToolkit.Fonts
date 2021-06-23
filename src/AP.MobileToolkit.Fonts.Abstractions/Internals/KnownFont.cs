namespace AP.MobileToolkit.Fonts.Internals
{
    internal class KnownFont : IFont
    {
        private IFont _font { get; }
        private string _glyph { get; }

        public KnownFont(IFont font, string selector)
        {
            _font = font;
            Selector = selector;
            _glyph = _font.GetGlyph(selector);
        }

        public string Selector { get; }

        public string Alias => _font.Alias;
        public string FontFileName => _font.FontFileName;

        public string GetGlyph(string name)
        {
            return _glyph;
        }
    }
}
