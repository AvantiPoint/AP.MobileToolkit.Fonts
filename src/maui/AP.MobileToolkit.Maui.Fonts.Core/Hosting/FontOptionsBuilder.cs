using System;
using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts
{
    public sealed class FontOptionsBuilder
    {
        internal readonly List<IFont> Fonts = new List<IFont>();

        public FontOptionsBuilder AddFont(IFont font)
        {
            Fonts.Add(font);
            return this;
        }

        public FontOptionsBuilder AddFonts(params IFont[] fonts)
        {
            Fonts.AddRange(fonts);
            return this;
        }
    }
}
