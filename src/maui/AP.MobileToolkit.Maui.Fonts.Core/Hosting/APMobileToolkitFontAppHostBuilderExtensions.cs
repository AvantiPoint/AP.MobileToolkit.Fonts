using System;
using System.ComponentModel;
using AP.MobileToolkit.Fonts.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

namespace AP.MobileToolkit.Fonts.Internals
{
    public static class APMobileToolkitFontAppHostBuilderExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MauiAppBuilder ConfigureIconFontsInternal(this MauiAppBuilder builder, Action<FontOptionsBuilder> configureOptions)
        {
            var options = new FontOptionsBuilder();
            configureOptions(options);
            builder.Services.TryAddSingleton<IFontRegistry, FontRegistryImplementation>();
            foreach (var font in options.Fonts)
            {
                builder.Services.AddSingleton<IFont>(font);
            }

            builder.ConfigureFonts(fc =>
            {
                foreach(var font in options.Fonts)
                {
                    fc.AddEmbeddedResourceFont(font.GetType().Assembly, font.FontFileName, font.Alias);
                }
            });

            builder.ConfigureImageSources((issc) =>
            {
                issc.AddService<IIconImageSource, IconImageSourceService>();
            });

            return builder;
        }
    }
}
