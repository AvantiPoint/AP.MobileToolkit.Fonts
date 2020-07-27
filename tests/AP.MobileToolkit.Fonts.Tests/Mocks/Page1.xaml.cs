using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1
    {
        public Page1()
        {
            InitializeComponent();
        }

        public StackLayout MainLayout => mainLayout;
    }
}
