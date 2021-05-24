using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui;
using UIKit;

namespace AP.MobileToolkit.Fonts.Controls
{
    partial class IconImageSourceService
    {
        public Task<IImageSourceServiceResult<UIImage>> GetImageAsync(IImageSource imageSource, float scale = 1, CancellationToken cancellationToken = default)
        {
            var fontImageSource = GetFontImageSource(imageSource);
            return _fontImageSourceService.GetImageAsync(fontImageSource, scale, cancellationToken);
        }
    }
}
