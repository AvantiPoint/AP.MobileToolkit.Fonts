namespace AP.MobileToolkit.Fonts
{
    public interface IFontRegistry
    {
        bool HasFont(string selector, out IFont font);
        IFont LocateFont(string selector);
    }
}
