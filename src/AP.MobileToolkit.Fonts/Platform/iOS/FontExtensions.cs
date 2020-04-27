using AP.MobileToolkit.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Core;
using Xamarin.Forms.Internals;

namespace AP.MobileToolkit.Platform
{
    internal static class FontExtensions
    {
        internal static string CleanseFontName(string fontName)
        {
            // First check Alias
            var (hasFontAlias, fontPostScriptName) = FontRegistrar.HasFont(fontName);
            if (hasFontAlias)
                return fontPostScriptName;

            var fontFile = FontFile.FromString(fontName);

            if (!string.IsNullOrWhiteSpace(fontFile.Extension))
            {
                var (hasFont, filePath) = FontRegistrar.HasFont(fontFile.FileNameWithExtension());
                if (hasFont)
                    return filePath ?? fontFile.PostScriptName;
            }
            else
            {
                foreach (var ext in FontFile.Extensions)
                {
                    var formated = fontFile.FileNameWithExtension(ext);
                    var (hasFont, filePath) = FontRegistrar.HasFont(formated);
                    if (hasFont)
                        return filePath;
                }
            }
            return fontFile.PostScriptName;
        }
    }
}
