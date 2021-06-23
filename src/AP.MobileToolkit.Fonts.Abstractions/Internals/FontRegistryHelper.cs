using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AP.MobileToolkit.Fonts.Internals
{
    public static class FontRegistryHelper
    {
        private static readonly object locker = new object();
        private static readonly List<KnownFont> _knownFonts = new List<KnownFont>();

        public static IFont LocateFont(IDictionary<string, IFont> registeredFonts, string selector)
        {
            lock(locker)
            {
                var knownFont = _knownFonts.FirstOrDefault(x => x.Selector == selector);
                if (knownFont != null)
                    return knownFont;

                var candidates = registeredFonts.Keys
                .Where(x => !string.IsNullOrEmpty(x) &&
                    (selector.StartsWith($"{x} ", StringComparison.InvariantCultureIgnoreCase) || selector.StartsWith($"{x}-", StringComparison.InvariantCultureIgnoreCase)));

                var key = string.Empty;
                switch (candidates.Count())
                {
                    case 0:
                        throw new KeyNotFoundException($"Could not locate a registered font for the icon {selector}");
                    case 1:
                        key = candidates.First();
                        break;
                    default:
                        key = candidates.FirstOrDefault(x => selector.StartsWith($"{x} ", StringComparison.InvariantCultureIgnoreCase)) ?? candidates.FirstOrDefault(x => selector.StartsWith($"{x}-", StringComparison.InvariantCultureIgnoreCase));
                        break;
                }

                var font = registeredFonts[key];
                knownFont = new KnownFont(font, selector);

                if (string.IsNullOrEmpty(knownFont.GetGlyph(selector)))
                    return font;

                _knownFonts.Add(knownFont);
                return knownFont;
            }
        }

        public static bool HasFont(IDictionary<string, IFont> registeredFonts, string selector, out IFont font)
        {
            try
            {
                font = LocateFont(registeredFonts, selector);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                font = null;
            }

            return font != null;
        }
    }
}
