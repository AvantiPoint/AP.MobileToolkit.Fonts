using System;
using AP.MobileToolkit.Fonts.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace AP.MobileToolkit.Fonts
{
    public static class AppHostBuilderExtensions
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
                issc.AddService<IIconImageSource>(x => 
                    new IconImageSourceService(x.GetRequiredService<IFontRegistry>()));
            });
        return builder;
        }
    }
}
