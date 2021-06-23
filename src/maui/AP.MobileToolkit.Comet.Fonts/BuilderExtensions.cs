using System;
using AP.MobileToolkit.Fonts.Controls;
using AP.MobileToolkit.Fonts.Internals;
using Comet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
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
                if (view is not Text text)
                    return;

                var selector = (string)text.GetEnvironment(KnownPropertyNames.Icon, cascades: false);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                text.SetEnvironment("Text", glyph, cascades: false);
                text.SetEnvironment("Font", Font.OfSize(fontName, view.Font.FontSize), cascades: false);
            };

            ButtonHandler.ButtonMapper[KnownPropertyNames.Icon] = (handler, view) =>
            {
                if (view is not Button button)
                    return;

                var selector = (string)button.GetEnvironment(KnownPropertyNames.Icon, cascades: false);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                button.SetEnvironment("Text", glyph, cascades: false);
                button.SetEnvironment("Font", Font.OfSize(fontName, view.Font.FontSize), cascades: false);
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

            var selector = (string)image.GetEnvironment(KnownPropertyNames.Icon, cascades: false);
            var color = (Color)(image.GetEnvironment(KnownPropertyNames.Color, cascades: false) ?? Colors.Black);
            var size = (double)(image.GetEnvironment(KnownPropertyNames.Size, cascades: false) ?? 12);
            image.SetEnvironment("Source",
                new IconImageSource
                {
                    Name = selector,
                    Color = color,
                    Size = size
                },
                cascades: false);
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
