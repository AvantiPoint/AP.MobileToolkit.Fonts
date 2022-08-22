using System;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Fonts.Controls;
using AP.MobileToolkit.Fonts.Internals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using IImage = Microsoft.Maui.IImage;

namespace Microsoft.Maui.Hosting
{
    public static class ToolkitFontsBuilderExtensions
    {
        public static MauiAppBuilder ConfigureIconFonts(this MauiAppBuilder builder, Action<FontOptionsBuilder> configureOptions)
        {
            LabelHandler.Mapper.AppendToMapping(KnownPropertyNames.Icon, (handler, view) =>
            {
                if (view is not Label label)
                    return;

                var selector = (string)label.GetValue(FontIcon.IconProperty);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                label.Text = glyph;
                label.FontFamily = fontName;
            });

            ButtonHandler.Mapper.AppendToMapping(KnownPropertyNames.Icon, (handler, view) =>
            {
                if (view is not Button button)
                    return;

                var selector = (string)button.GetValue(FontIcon.IconProperty);
                (var glyph, string fontName) = Lookup(selector, handler.MauiContext);
                button.Text = glyph;
                button.FontFamily = fontName;
            });

            ImageHandler.Mapper.AppendToMapping(KnownPropertyNames.Icon, ImageMapper);
            ImageHandler.Mapper.AppendToMapping(KnownPropertyNames.Color, ImageMapper);
            ImageHandler.Mapper.AppendToMapping(KnownPropertyNames.Size, ImageMapper);

            return builder.ConfigureIconFontsInternal(configureOptions);
        }

        private static void ImageMapper(IImageHandler handler, IImage view)
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
