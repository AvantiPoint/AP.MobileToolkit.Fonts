using System;
using System.Collections.Generic;
using System.Linq;

namespace AP.MobileToolkit.Fonts
{
    internal class FontRegistryImplementation : IFontRegistry
    {
        private IReadOnlyDictionary<string, IFont> RegisteredFonts { get; }

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
            var alias = selector.Split(new[] { ' ', '-' }).First();
            var key = RegisteredFonts.Keys.FirstOrDefault(x => x.Equals(alias, StringComparison.InvariantCultureIgnoreCase));
            return string.IsNullOrEmpty(key) ? throw new KeyNotFoundException($"Could not locate a registered font with the alias {alias}") : RegisteredFonts[key];
        }

        public bool HasFont(string selector, out IFont font)
        {
            try
            {
                font = LocateFont(selector);
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
