using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AP.MobileToolkit.Controls
{
    public class IconImageSource : ImageSource
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(IconImageSource), null, BindingMode.OneTime);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(double), typeof(IconImageSource), null, BindingMode.OneTime);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(IconImageSource), null);

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public double Size
        {
            get => (double)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            OnSourceChanged();
        }
    }
}
