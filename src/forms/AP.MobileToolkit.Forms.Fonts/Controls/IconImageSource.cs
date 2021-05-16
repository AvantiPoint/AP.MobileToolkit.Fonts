using System.Runtime.CompilerServices;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;

namespace AP.MobileToolkit.Controls
{
    public class IconImageSource : ImageSource
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(IconImageSource), null, BindingMode.OneTime, propertyChanged: OnIconValueChanged);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(double), typeof(IconImageSource), 12.0, BindingMode.OneTime, propertyChanged: OnIconValueChanged);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(IconImageSource), Color.Default, propertyChanged: OnIconValueChanged);

        private static void OnIconValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is IconImageSource imageSource)
            {
                imageSource.OnSourceChanged();
            }
        }

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

        internal FontImageSource ToFontImageSource(IFont font) =>
            new FontImageSource
            {
                Glyph = font.GetGlyph(Name),
                FontFamily = font.Alias,
                Size = Size == 0 ? Device.GetNamedSize(NamedSize.Default, new Label()) : Size,
                Color = Color
            };
    }
}
