using System.Threading;
using System.Threading.Tasks;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace AP.MobileToolkit.Platform
{
    [Preserve(AllMembers = true)]
    public partial class IconImageSourceHandler : IImageSourceHandler
    {
        public Task<UIImage> LoadImageAsync(
            ImageSource imagesource,
            CancellationToken cancelationToken = default(CancellationToken),
            float scale = 1f)
        {
            UIImage image = null;

            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var font))
            {
                return new FontImageSourceHandler().LoadImageAsync(iconsource.ToFontImageSource(font), cancelationToken, scale);
            }

            return Task.FromResult(image);
        }
    }
}
