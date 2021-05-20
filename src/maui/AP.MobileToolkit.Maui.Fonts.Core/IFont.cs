namespace AP.MobileToolkit.Fonts
{
    public interface IFont
    {
        string Alias { get; }

        string FontFileName { get; }

        string GetGlyph(string name);
    }
}
