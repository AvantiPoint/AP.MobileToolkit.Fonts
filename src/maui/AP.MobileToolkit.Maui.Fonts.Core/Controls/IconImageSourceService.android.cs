using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Microsoft.Maui;

namespace AP.MobileToolkit.Fonts.Controls
{
    partial class IconImageSourceService
    {
        public Task<IImageSourceServiceResult<Drawable>> GetDrawableAsync(IImageSource imageSource, Context context, CancellationToken cancellationToken = default)
        {
            var fontImageSource = GetFontImageSource(imageSource);
            return _fontImageSourceService.GetDrawableAsync(fontImageSource, context, cancellationToken);
        }

        public Task<IImageSourceServiceResult> LoadDrawableAsync(IImageSource imageSource, ImageView imageView, CancellationToken cancellationToken = default)
        {
            var fontImageSource = GetFontImageSource(imageSource);
            return _fontImageSourceService.LoadDrawableAsync(fontImageSource, imageView, cancellationToken);
        }
    }
}
