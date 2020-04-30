using System.Runtime.CompilerServices;
using Xamarin.Forms;

#if XAMARIN_IOS
[assembly: Foundation.LinkerSafe]
#elif MONOANDROID
[assembly: Android.LinkerSafe]
#endif
[assembly: InternalsVisibleTo("AP.MobileToolkit.Fonts.Tests")]
[assembly: ExportFont(AP.MobileToolkit.Fonts.FontAwesomeBrands.FontName)]
namespace AP.MobileToolkit.Fonts
{
#if XAMARIN_IOS
    [Foundation.Preserve(AllMembers = true)]
#elif MONOANDROID
    [Android.Runtime.Preserve(AllMembers = true)]
#endif
    public static class FontAwesomeBrands
    {
        internal const string FontName = "fa-brands-400.ttf";

        public const string Prefix = "fab";

        public const string Version = "5.12.0";

        public static readonly IFont Font = new EmbeddedWebFont(FontName, Prefix, "fontawesome.min.css", typeof(FontAwesomeBrands));
    }
}
