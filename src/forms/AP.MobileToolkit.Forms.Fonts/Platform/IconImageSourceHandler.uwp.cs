using System.Threading;
using System.Threading.Tasks;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using WindowsImageSource = Windows.UI.Xaml.Media.ImageSource;

namespace AP.MobileToolkit.Platform
{
    public class IconImageSourceHandler : IImageSourceHandler
    {
        readonly float _minimumDpi = 300;

        public Task<WindowsImageSource> LoadImageAsync(ImageSource imagesource, CancellationToken cancellationToken = default)
        {
            if (!(imagesource is IconImageSource iconsource) || !FontRegistry.HasFont(iconsource.Name, out var font))
                return Task.FromResult(default(WindowsImageSource));

            return new FontImageSourceHandler().LoadImageAsync(iconsource.ToFontImageSource(font), cancellationToken);
        }
    }
}
