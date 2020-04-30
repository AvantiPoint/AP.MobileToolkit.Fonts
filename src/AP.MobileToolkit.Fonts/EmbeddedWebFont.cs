using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AP.MobileToolkit.Fonts.StyleSheets;

namespace AP.MobileToolkit.Fonts
{
    public class EmbeddedWebFont : FontBase
    {
        private readonly Dictionary<string, string> _glyphs;
        private readonly ICssParser _cssParser;

        public EmbeddedWebFont(string fontFileName, string alias, string cssFileName, Type resolvingType)
            : this(fontFileName, alias, cssFileName, resolvingType.Assembly)
        {
        }

        public EmbeddedWebFont(string fontFileName, string alias, string cssFileName, Assembly assembly)
            : base(fontFileName, alias)
        {
            _glyphs = new Dictionary<string, string>();
            _cssParser = new CssParser();
            _cssParser.ReadCSSFile(GetResourceStream(cssFileName, assembly));
        }

        public override string GetGlyph(string name)
        {
            if (_glyphs.ContainsKey(name))
            {
                return _glyphs[name];
            }

            return _glyphs[name] = _cssParser.GetFontIcon(name);
        }

        private static Stream GetResourceStream(string resourceName, Assembly assembly)
        {
            var resourceId = assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase) || x.EndsWith(resourceName, StringComparison.InvariantCultureIgnoreCase));

            return string.IsNullOrEmpty(resourceId) ? Stream.Null : assembly.GetManifestResourceStream(resourceId);
        }
    }
}
