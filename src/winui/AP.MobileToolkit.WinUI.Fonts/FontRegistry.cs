using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AP.MobileToolkit.Fonts
{
    public static partial class FontRegistry
    {
        private static readonly Dictionary<string, IFont> _registeredFonts = new Dictionary<string, IFont>();
        internal static IReadOnlyDictionary<string, IFont> RegisteredFonts => _registeredFonts;

        public static void RegisterFonts(params IFont[] fonts)
        {
            foreach (var font in fonts)
            {
                if (_registeredFonts.ContainsKey(font.Alias))
                {
                    var existingFont = _registeredFonts[font.Alias];
                    if (existingFont.FontFileName == font.FontFileName)
                        continue;

                    throw new InvalidOperationException($"An existing registration already exists for the Alias {font.Alias}. Existing: '{existingFont.FontFileName}' New: '{font.FontFileName}'");
                }

                CacheFont(font);
                _registeredFonts.Add(font.Alias, font);

            }
        }

        internal static IFont LocateFont(string selector)
        {
            var alias = selector.Split(new[] { ' ', '-' }).First();
            var key = _registeredFonts.Keys.FirstOrDefault(x => x.Equals(alias, StringComparison.InvariantCultureIgnoreCase));
            return string.IsNullOrEmpty(key) ? throw new KeyNotFoundException($"Could not locate a registered font with the alias {alias}") : _registeredFonts[key];
        }

        internal static bool HasFont(string selector, out IFont font)
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

        internal static void Clear() => _registeredFonts.Clear();

        private static void CacheFont(IFont font)
        {
            if (!Directory.Exists(FontCacheDirectory))
                Directory.CreateDirectory(FontCacheDirectory);

            var outputPath = Path.Combine(FontCacheDirectory, font.FontFileName);
            if(!File.Exists(outputPath))
            {
                var assembly = font.GetType().Assembly;
                var resourceId = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(font.FontFileName));
                if (string.IsNullOrEmpty(resourceId))
                    throw new FontNotFoundException(font);

                using var resourceStream = assembly.GetManifestResourceStream(resourceId);
                using var fileStream = File.OpenWrite(outputPath);
                resourceStream.CopyTo(fileStream);
            }

            PlatformInitFont(outputPath, font);
        }
    }
}
