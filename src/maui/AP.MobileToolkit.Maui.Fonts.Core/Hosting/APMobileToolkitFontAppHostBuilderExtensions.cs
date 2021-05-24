using System;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Fonts.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Maui.Hosting
{
    public static class APMobileToolkitFontAppHostBuilderExtensions
    {
        public static IAppHostBuilder UseMobileToolkitFonts(this IAppHostBuilder builder, Action<FontOptionsBuilder> configureOptions)
        {
            var options = new FontOptionsBuilder();
            configureOptions(options);
            builder.ConfigureServices(x =>
            {
                x.AddSingleton<IFontRegistry, FontRegistryImplementation>();
                foreach (var font in options.Fonts)
                {
                    x.AddSingleton<IFont>(font);
                }
            });

            builder.ConfigureFonts(fc =>
            {
                foreach(var font in options.Fonts)
                {
                    fc.AddEmeddedResourceFont(font.GetType().Assembly, font.FontFileName, font.Alias);
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
