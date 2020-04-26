using System.Runtime.CompilerServices;
using Xamarin.Forms;

[assembly: InternalsVisibleTo("AP.MobileToolkit.Fonts.Tests")]
[assembly: ExportFont(AP.MobileToolkit.Fonts.FontAwesomeSolid.FontName)]
namespace AP.MobileToolkit.Fonts
{
    public static class FontAwesomeSolid
    {
        internal const string FontName = "fa-solid-900.ttf";

        public const string Prefix = "fas";

        public const string Version = "5.12.0";

        public static readonly IFont Font = new EmbeddedWebFont(FontName, Prefix, "fontawesome.min.css", typeof(FontAwesomeSolid));
    }
}
