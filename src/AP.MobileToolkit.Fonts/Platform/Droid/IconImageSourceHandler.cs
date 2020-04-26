using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Util;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;
using Path = System.IO.Path;

[assembly: ExportImageSourceHandler(typeof(IconImageSource), typeof(AP.MobileToolkit.Platform.IconImageSourceHandler))]
namespace AP.MobileToolkit.Platform
{
    internal class IconImageSourceHandler : IImageSourceHandler
    {
        public Task<Bitmap> LoadImageAsync(ImageSource imagesource, Context context, CancellationToken cancelationToken = default) =>
            new Task<Bitmap>(() => LoadImage(imagesource, context));

        private Bitmap LoadImage(ImageSource imagesource, Context context)
        {
            Bitmap image = null;
            if (imagesource is IconImageSource iconsource && FontRegistry.HasFont(iconsource.Name, out var font))
            {
                var paint = new Paint
                {
                    TextSize = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)iconsource.Size, context.Resources.DisplayMetrics),
                    Color = (iconsource.Color != Color.Default ? iconsource.Color : Color.White).ToAndroid(),
                    TextAlign = Paint.Align.Left,
                    AntiAlias = true,
                };

                using (var typeface = Typeface.CreateFromAsset(context.ApplicationContext.Assets, font.FontFileName))
                    paint.SetTypeface(typeface);

                var glyph = font.GetGlyph(iconsource.Name);
                var width = (int)(paint.MeasureText(glyph) + .5f);
                var baseline = (int)(-paint.Ascent() + .5f);
                var height = (int)(baseline + paint.Descent() + .5f);
                image = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
                var canvas = new Canvas(image);
                canvas.DrawText(glyph, 0, baseline, paint);
            }

            return image;
        }
    }
}
