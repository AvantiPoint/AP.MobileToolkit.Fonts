using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using AP.MobileToolkit.Fonts;

namespace MauiSampleFonts
{
    public class Startup : IStartup
    {
        public void Configure(IAppHostBuilder appBuilder)
        {
            appBuilder
                .UseMauiApp<App>()
                .ConfigureIconFonts(fonts =>
                {
                    fonts.AddFonts(
                        DevIcons.Font,
                        FontAwesomeBrands.Font,
                        FontAwesomeRegular.Font,
                        FontAwesomeSolid.Font,
                        MaterialIcons.Font,
                        MaterialIconsOutlined.Font,
                        MaterialIconsRound.Font,
                        MaterialIconsSharp.Font);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
        }
    }
}
