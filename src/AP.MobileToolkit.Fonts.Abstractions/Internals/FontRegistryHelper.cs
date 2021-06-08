using System;
using System.Collections.Generic;
using System.Linq;

namespace AP.MobileToolkit.Fonts.Internals
{
    public static class FontRegistryHelper
    {
        public static IFont LocateFont(IDictionary<string, IFont> registeredFonts, string selector)
        {
            var candidates = registeredFonts.Keys
                .Where(x => !string.IsNullOrEmpty(x) && 
                    (selector.StartsWith($"{x} ", StringComparison.InvariantCultureIgnoreCase) || selector.StartsWith($"{x}-", StringComparison.InvariantCultureIgnoreCase)));

            var key = string.Empty;
            switch(candidates.Count())
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

            return registeredFonts[key];
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
