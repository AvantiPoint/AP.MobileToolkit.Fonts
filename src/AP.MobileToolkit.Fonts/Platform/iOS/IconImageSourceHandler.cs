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

[assembly: ExportImageSourceHandler(typeof(IconImageSource), typeof(AP.MobileToolkit.Platform.IconImageSourceHandler))]
namespace AP.MobileToolkit.Platform
{
    internal class IconImageSourceHandler : IImageSourceHandler
    {
        // should this be the default color on the BP for iOS?
        readonly Color _defaultColor = Color.White;

        public Task<UIImage> LoadImageAsync(ImageSource imagesource, CancellationToken cancelationToken = default, float scale = 1)
        {
            UIImage image = null;
            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var icon))
            {
                (var hasFont, var fontPath) = Xamarin.Forms.Internals.FontRegistrar.HasFont(icon.FontFileName);

                if (!hasFont)
                {
                    return Task.FromResult(image);
                }

                var iconcolor = iconsource.Color.IsDefault ? _defaultColor : iconsource.Color;
                var imagesize = new SizeF((float)iconsource.Size, (float)iconsource.Size);
                var font = UIFont.FromName(fontPath ?? string.Empty, (float)iconsource.Size) ??
                    UIFont.SystemFontOfSize((float)iconsource.Size);

                UIGraphics.BeginImageContextWithOptions(imagesize, false, 0f);
                var glyph = icon.GetGlyph(iconsource.Name);
                var attString = new NSAttributedString(glyph, font: font, foregroundColor: iconcolor.ToUIColor());
                var ctx = new NSStringDrawingContext();
                var boundingRect = attString.GetBoundingRect(imagesize, (NSStringDrawingOptions)0, ctx);
                attString.DrawString(new RectangleF(
                    (imagesize.Width / 2) - (boundingRect.Size.Width / 2),
                    (imagesize.Height / 2) - (boundingRect.Size.Height / 2),
                    imagesize.Width,
                    imagesize.Height));
                image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                if (iconcolor != _defaultColor)
                    image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            return Task.FromResult(image);
        }
    }

    // Temporary Class until Clancey's fix is merged
    [Preserve(AllMembers = true)]
    public class EmbeddedFontLoader : IEmbeddedFontLoader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1316:Tuple element names should use correct casing", Justification = "Temporary override of Xamarin.Forms service")]
        public (bool success, string filePath) LoadFont(Xamarin.Forms.EmbeddedFont font)
        {
            try
            {
                var data = NSData.FromStream(font.ResourceStream);
                var fonts = UIKit.UIFont.FamilyNames.ToList();
                var provider = new CGDataProvider(data);
                var cGFont = CGFont.CreateFromProvider(provider);
                if (CTFontManager.RegisterGraphicsFont(cGFont, out var error))
                {
                    var newFonts = UIKit.UIFont.FamilyNames.ToList();
                    var diff = newFonts.Except(fonts).ToList();
                    return (true, diff.FirstOrDefault());
                }
                Debug.WriteLine(error.Description);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return (false, null);
        }
    }
}
