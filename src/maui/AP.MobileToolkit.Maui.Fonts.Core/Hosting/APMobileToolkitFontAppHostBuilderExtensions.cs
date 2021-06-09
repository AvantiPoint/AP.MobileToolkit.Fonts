using System;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Fonts.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.LifecycleEvents;

namespace Microsoft.Maui.Hosting
{
    public static class APMobileToolkitFontAppHostBuilderExtensions
    {
        public static IAppHostBuilder ConfigureIconFonts(this IAppHostBuilder builder, Action<FontOptionsBuilder> configureOptions)
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

            builder.ConfigureLifecycleEvents((ctx, lifecyle) =>
            {
#if ANDROID
                lifecyle.AddAndroid(b =>
                {
                    b.OnStart(_ =>
                    {
                        RegistryLocator.Registry = MauiApplication.Current.Services.GetRequiredService<IFontRegistry>();
                    });
                });
#elif IOS || MACCATALYST
                lifecyle.AddiOS(b =>
                {
                    b.FinishedLaunching((app, options) =>
                    {
                        RegistryLocator.Registry = MauiUIApplicationDelegate.Current.Services.GetRequiredService<IFontRegistry>();
                        return true;
                    });
                });
#elif WINDOWS
                lifecyle.AddWindows(b =>
                {
                    b.OnLaunched((app, args) =>
                    {
                        RegistryLocator.Registry = MauiWinUIApplication.Current.Services.GetRequiredService<IFontRegistry>();
                    });
                });
#endif
            });

            return builder;
        }
    }
}
