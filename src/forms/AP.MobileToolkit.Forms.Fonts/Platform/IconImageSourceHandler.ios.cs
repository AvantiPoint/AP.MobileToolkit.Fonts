using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Color = Xamarin.Forms.Color;
using RectangleF = CoreGraphics.CGRect;

namespace AP.MobileToolkit.Platform
{
    public class IconImageSourceHandler : IImageSourceHandler
    {
        // should this be the default color on the BP for iOS?
        readonly Color _defaultColor = UIColor.LabelColor.ToColor();
        /*
        public Task<UIImage> LoadImageAsync(ImageSource imagesource, CancellationToken cancelationToken = default, float scale = 1)
        {
            UIImage image = null;

            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var font))
            {
                // This will allow lookup from the Embedded Fonts
                var glyph = font.GetGlyph(iconsource.Name);
                var cleansedname = FontExtensions.CleanseFontName(font.Alias);
                var uifont = UIFont.FromName(cleansedname ?? string.Empty, (float)iconsource.Size) ??
                    UIFont.SystemFontOfSize((float)iconsource.Size);
                var iconcolor = iconsource.Color.IsDefault ? _defaultColor : iconsource.Color;
                var attString = new NSAttributedString(glyph, font: uifont, foregroundColor: iconcolor.ToUIColor());
                var imagesize = ((NSString)glyph).GetSizeUsingAttributes(attString.GetUIKitAttributes(0, out _));

                UIGraphics.BeginImageContextWithOptions(imagesize, false, 0f);
                var ctx = new NSStringDrawingContext();
                var boundingRect = attString.GetBoundingRect(imagesize, (NSStringDrawingOptions)0, ctx);
                attString.DrawString(new RectangleF(
                    (imagesize.Width / 2) - (boundingRect.Size.Width / 2),
                    (imagesize.Height / 2) - (boundingRect.Size.Height / 2),
                    imagesize.Width,
                    imagesize.Height));
                image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                if (image != null && iconcolor != _defaultColor)
                    image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            return Task.FromResult(image);
        }
        */

        public Task<UIImage> LoadImageAsync(
            ImageSource imagesource,
            CancellationToken cancelationToken = default(CancellationToken),
            float scale = 1f)
        {
            UIImage image = null;

            // var fontsource = imagesource as FontImageSource;
            // if (fontsource != null)
            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var iconFont))
            {
                // This will allow lookup from the Embedded Fonts
                if (iconsource.Size == 0)
                    iconsource.Size = 12;

                var cleansedname = FontExtensions.CleanseFontName(iconFont.FontFileName);
                var font = UIFont.FromName(cleansedname ?? string.Empty, (float)iconsource.Size) ??
                    UIFont.SystemFontOfSize((float)iconsource.Size);
                var iconcolor = iconsource.Color.IsDefault ? _defaultColor : iconsource.Color;
                var glyph = iconFont.GetGlyph(iconsource.Name);
                var attString = new NSAttributedString(glyph, font: font, foregroundColor: iconcolor.ToUIColor());
                var imagesize = ((NSString)glyph).GetSizeUsingAttributes(attString.GetUIKitAttributes(0, out _));

                UIGraphics.BeginImageContextWithOptions(imagesize, false, 0f);
                var ctx = new NSStringDrawingContext();
                var boundingRect = attString.GetBoundingRect(imagesize, (NSStringDrawingOptions)0, ctx);
                attString.DrawString(new RectangleF(
                    (imagesize.Width / 2) - (boundingRect.Size.Width / 2),
                    (imagesize.Height / 2) - (boundingRect.Size.Height / 2),
                    imagesize.Width,
                    imagesize.Height));
                image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                if (image != null && iconcolor != _defaultColor)
                    image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            return Task.FromResult(image);
        }
    }
}
