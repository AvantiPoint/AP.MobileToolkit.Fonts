using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AP.MobileToolkit.Fonts.StyleSheets;

namespace AP.MobileToolkit.Fonts
{
    public interface IFont
    {
        string Alias { get; }
        string FontFileName { get; }

        string GetGlyph(string name);
    }
}
