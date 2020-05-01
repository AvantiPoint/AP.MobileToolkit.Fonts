using System.Runtime.CompilerServices;
using Xamarin.Forms;

[assembly: InternalsVisibleTo("AP.MobileToolkit.Fonts.Tests")]
[assembly: ExportFont(AP.MobileToolkit.Fonts.FontAwesomeRegular.FontName)]
namespace AP.MobileToolkit.Fonts
{
#if XAMARIN_IOS
    [Foundation.Preserve(AllMembers = true)]
#elif MONOANDROID
    [Android.Runtime.Preserve(AllMembers = true)]
#endif
    public static class FontAwesomeRegular
    {
        internal const string FontName = "fa-regular-400.ttf";

        public const string Prefix = "far";

        public const string Version = "5.13.0";

        public static readonly IFont Font = new EmbeddedWebFont(FontName, Prefix, "fontawesome.min.css", typeof(FontAwesomeRegular));
    }
}
