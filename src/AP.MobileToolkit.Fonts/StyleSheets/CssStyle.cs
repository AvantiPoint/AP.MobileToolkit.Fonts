using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts.StyleSheets
{
    internal class CssStyle
    {
        public string SelectorText { get; set; }

        public IList<KeyValuePair<string, string>> Styles { get; set; }
    }
}
