using System;

namespace AP.MobileToolkit.Fonts
{
    public sealed class FontNotFoundException : Exception
    {
        public FontNotFoundException(IFont font)
            : base($"Could not locate an embedded font with the name '{font.FontFileName}'")
        {
        }

        public IFont Font { get; }
    }
}
