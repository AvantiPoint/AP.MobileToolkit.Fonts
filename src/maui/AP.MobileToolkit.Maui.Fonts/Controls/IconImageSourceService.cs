using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace AP.MobileToolkit.Fonts.Controls
{
    public partial class IconImageSourceService : IImageSourceService<IIconImageSource>
    {
        private IFontRegistry _fontRegistry { get; }

        public IconImageSourceService(IFontRegistry fontRegistry)
        {
            _fontRegistry = fontRegistry;
        }
    }
}
