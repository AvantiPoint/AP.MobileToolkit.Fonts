using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace AP.MobileToolkit.Fonts.Controls
{
    partial class IconImageSourceService
    {
        public Task<IImageSourceServiceResult<Microsoft.UI.Xaml.Media.ImageSource>> GetImageSourceAsync(IImageSource imageSource, float scale = 1, CancellationToken cancellationToken = default)
        {
            var fontImageSource = GetFontImageSource(imageSource);
            return _fontImageSourceService.GetImageSourceAsync(fontImageSource, scale, cancellationToken);
        }
    }
}
