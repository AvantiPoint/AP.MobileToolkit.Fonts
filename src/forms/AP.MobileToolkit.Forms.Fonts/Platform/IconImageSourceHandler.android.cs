using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace AP.MobileToolkit.Platform
{
    [Preserve(AllMembers = true)]
    public partial class IconImageSourceHandler : IImageSourceHandler
    {
        public Task<Bitmap> LoadImageAsync(ImageSource imagesource, Context context, CancellationToken cancelationToken = default)
        {
            Bitmap image = null;
            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var font))
            {
                return new FontImageSourceHandler().LoadImageAsync(iconsource.ToFontImageSource(font), context, cancelationToken);
            }

            return Task.FromResult(image);
        }
    }
}
