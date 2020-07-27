using System;
using System.Threading;
using System.Threading.Tasks;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using WindowsImageSource = Windows.UI.Xaml.Media.ImageSource;

namespace AP.MobileToolkit.Platform
{
    public class IconImageSourceHandler : IImageSourceHandler
    {
        readonly float _minimumDpi = 300;

        public Task<WindowsImageSource> LoadImageAsync(ImageSource imagesource, CancellationToken cancellationToken = default) =>
            new Task<WindowsImageSource>(() => LoadImage(imagesource));

        private WindowsImageSource LoadImage(ImageSource imagesource)
        {
            if (!(imagesource is IconImageSource iconsource) || !FontRegistry.HasFont(iconsource.Name, out var icon))
                return null;

            var device = CanvasDevice.GetSharedDevice();
            var dpi = Math.Max(_minimumDpi, Windows.Graphics.Display.DisplayInformation.GetForCurrentView().LogicalDpi);

            var textFormat = new CanvasTextFormat
            {
                FontFamily = icon.FontFileName,
                FontSize = (float)iconsource.Size,
                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,
                Options = CanvasDrawTextOptions.Default
            };

            var glyph = icon.GetGlyph(iconsource.Name);
            using (var layout = new CanvasTextLayout(device, glyph, textFormat, (float)iconsource.Size, (float)iconsource.Size))
            {
                var canvasWidth = (float)layout.LayoutBounds.Width + 2;
                var canvasHeight = (float)layout.LayoutBounds.Height + 2;

                var imageSource = new CanvasImageSource(device, canvasWidth, canvasHeight, dpi);
                using (var ds = imageSource.CreateDrawingSession(Windows.UI.Colors.Transparent))
                {
                    var iconcolor = (iconsource.Color != Color.Default ? iconsource.Color : Color.White).ToWindowsColor();

                    // offset by 1 as we added a 1 inset
                    var x = (float)layout.DrawBounds.X * -1;

                    ds.DrawTextLayout(layout, x, 1f, iconcolor);
                }

                return imageSource;
            }
        }
    }
}
