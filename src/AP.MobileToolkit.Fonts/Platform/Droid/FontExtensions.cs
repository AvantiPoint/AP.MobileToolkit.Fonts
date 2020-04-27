using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using AP.MobileToolkit.Controls;
using Xamarin.Forms;

[assembly: ExportImageSourceHandler(typeof(IconImageSource), typeof(AP.MobileToolkit.Platform.IconImageSourceHandler))]
namespace AP.MobileToolkit.Platform
{
    internal static class FontExtensions
    {
        private static Dictionary<string, Typeface> _mappings = new Dictionary<string, Typeface>();

        public static Typeface ToTypeFace(this string fontAlias)
        {
            if (_mappings.ContainsKey(fontAlias))
                return _mappings[fontAlias];

            // Xamarin.Forms.Platform.Android
            var xfAssembly = typeof(Xamarin.Forms.Forms).Assembly;
            var xfFontExtensions = xfAssembly.ExportedTypes.First(x => x.FullName == "Xamarin.Forms.Platform.Android.FontExtensions");
            var toTypeFaceMethod = xfFontExtensions.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).First();
            var typeface = (Typeface)toTypeFaceMethod.Invoke(null, new object[] { fontAlias, FontAttributes.None });
            _mappings.Add(fontAlias, typeface);
            return typeface;
        }
    }
}
