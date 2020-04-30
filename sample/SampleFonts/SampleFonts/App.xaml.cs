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

            var tabbed = new TabbedPage();
            var main = new WebClasses();
            var mainTab = new NavigationPage(main)
            {
                BindingContext = main
            };
            var mappings = new Mappings();
            var mappingsTab = new NavigationPage(mappings)
            {
                BindingContext = mappings
            };
            mainTab.SetBinding(Page.TitleProperty, "Title");
            mainTab.SetBinding(Page.IconImageSourceProperty, "IconImageSource");
            mappingsTab.SetBinding(Page.TitleProperty, "Title");
            mappingsTab.SetBinding(Page.IconImageSourceProperty, "IconImageSource");
            tabbed.Children.Add(mainTab);
            tabbed.Children.Add(mappingsTab);
            tabbed.Children.Add(new InfoPage());
            MainPage = tabbed;
        }
    }
}
