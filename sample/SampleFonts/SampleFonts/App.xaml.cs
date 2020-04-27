using AP.MobileToolkit.Fonts;
using Xamarin.Forms;

namespace SampleFonts
{
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        FontRegistry.RegisterFonts(
            FontAwesomeBrands.Font,
            FontAwesomeRegular.Font,
            FontAwesomeSolid.Font);

        MainPage = new NavigationPage(new MainPage());
    }
}
}
