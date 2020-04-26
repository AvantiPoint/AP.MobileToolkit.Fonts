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

[assembly: ExportImageSourceHandler(typeof(IconImageSource), typeof(AP.MobileToolkit.Platform.IconImageSourceHandler))]
namespace AP.MobileToolkit.Platform
{
    internal class IconImageSourceHandler : IImageSourceHandler
    {
        float _minimumDpi = 300;

        public Task<WindowsImageSource> LoadImageAsync(ImageSource imagesource, CancellationToken cancellationToken = default) =>
            new Task<WindowsImageSource>(() => LoadImage(imagesource));

        private WindowsImageSource LoadImage(ImageSource imagesource)
        {
            if (!(imagesource is IconImageSource iconsource) || !FontRegistry.HasFont(iconsource.Name, out var icon))
                return null;

            var device = CanvasDevice.GetSharedDevice();
            var dpi = Math.Max(_minimumDpi, Windows.Graphics.Display.DisplayInformation.GetForCurrentView().LogicalDpi);
            var canvasSize = (float)iconsource.Size + 2;

            var canvas = new CanvasImageSource(device, canvasSize, canvasSize, dpi);
            using (var ds = canvas.CreateDrawingSession(Windows.UI.Colors.Transparent))
            {
                var textFormat = new CanvasTextFormat
                {
                    FontFamily = icon.FontFileName,
                    FontSize = (float)iconsource.Size,
                    HorizontalAlignment = CanvasHorizontalAlignment.Center,
                    Options = CanvasDrawTextOptions.Default,
                };

                var iconcolor = ToWindowsColor(iconsource.Color != Color.Default ? iconsource.Color : Color.White);
                var glyph = icon.GetGlyph(iconsource.Name);
                ds.DrawText(glyph, textFormat.FontSize / 2, 0, iconcolor, textFormat);
            }

            return canvas;
        }

        public static Windows.UI.Color ToWindowsColor(Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
}
