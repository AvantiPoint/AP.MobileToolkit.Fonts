using AP.MobileToolkit.Fonts;

namespace MauiSampleFonts
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }
    }
}
