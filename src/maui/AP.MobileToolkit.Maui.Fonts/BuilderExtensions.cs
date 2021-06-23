using System;
using AP.MobileToolkit.Fonts.Controls;
using AP.MobileToolkit.Fonts.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using IImage = Microsoft.Maui.IImage;

namespace AP.MobileToolkit.Fonts
{
    public static class BuilderExtensions
    {
        public static IAppHostBuilder ConfigureIconFonts(this IAppHostBuilder builder, Action<FontOptionsBuilder> configureOptions)
        {
            LabelHandler.LabelMapper[KnownPropertyNames.Icon] = (handler, view) =>
            {
                if (view is not Label label)
                    return;

                var selector = (string)label.GetValue(FontIcon.IconProperty);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                label.Text = glyph;
                label.FontFamily = fontName;
            };

            ButtonHandler.ButtonMapper[KnownPropertyNames.Icon] = (handler, view) =>
            {
                if (view is not Button button)
                    return;

                var selector = (string)button.GetValue(FontIcon.IconProperty);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                button.Text = glyph;
                button.FontFamily = fontName;
            };

            ImageHandler.ImageMapper[KnownPropertyNames.Icon] = ImageMapper;
            ImageHandler.ImageMapper[KnownPropertyNames.Color] = ImageMapper;
            ImageHandler.ImageMapper[KnownPropertyNames.Size] = ImageMapper;

            return builder.ConfigureIconFontsInternal(configureOptions);
        }

        private static void ImageMapper(ImageHandler handler, IImage view)
        {
            if (view is not Image image)
                return;

            var selector = (string)image.GetValue(FontIcon.IconProperty);
            image.Source = new IconImageSource
            {
                Name = selector,
                Color = (Color)image.GetValue(FontIcon.ColorProperty),
                Size = (double)image.GetValue(FontIcon.SizeProperty)
            };
        }

        private static (string glyph, string fontName) Lookup(string selector, IMauiContext context)
        {
            string glyph = null;
            string fontName = null;

            if (context?.Services is null)
                return (glyph, fontName);

            var registry = context.Services.GetRequiredService<IFontRegistry>();
            if (!registry.HasFont(selector, out var font))
                return (glyph, fontName);

            fontName = font.FontFileName;
            glyph = font.GetGlyph(selector);
            return (glyph, fontName);
        }
    }
}
