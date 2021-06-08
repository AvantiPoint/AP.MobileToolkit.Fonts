using System;
using System.Collections.Generic;
using System.Linq;
using AP.MobileToolkit.Fonts.Internals;

namespace AP.MobileToolkit.Fonts
{
    internal class FontRegistryImplementation : IFontRegistry
    {
        private IDictionary<string, IFont> RegisteredFonts { get; }

        public FontRegistryImplementation(IEnumerable<IFont> fonts)
        {
            if (fonts is null)
            {
                RegisteredFonts = new Dictionary<string, IFont>();
                return;
            }

            var registeredFonts = new Dictionary<string, IFont>();
            foreach (var font in fonts)
            {
                if (registeredFonts.ContainsKey(font.Alias))
                {
                    var existingFont = registeredFonts[font.Alias];
                    if (existingFont.FontFileName == font.FontFileName)
                        continue;

                    throw new InvalidOperationException($"An existing registration already exists for the Alias {font.Alias}. Existing: '{existingFont.FontFileName}' New: '{font.FontFileName}'");
                }

                registeredFonts.Add(font.Alias, font);
            }

            RegisteredFonts = registeredFonts;
        }

        public IFont LocateFont(string selector)
        {
            return FontRegistryHelper.LocateFont(RegisteredFonts, selector);
        }

        public bool HasFont(string selector, out IFont font)
        {
            return FontRegistryHelper.HasFont(RegisteredFonts, selector, out font);
        }
    }
}
