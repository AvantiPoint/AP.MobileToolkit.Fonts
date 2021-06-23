using AP.MobileToolkit.Fonts;
using Xamarin.Forms;

namespace AP.MobileToolkit.Controls
{
    public static class FontIcon
    {
        public static readonly BindableProperty IconProperty =
            BindableProperty.CreateAttached("Icon", typeof(string), typeof(FontIcon), null, propertyChanged: OnIconChanged);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached("Color", typeof(Color), typeof(FontIcon), Color.Default, propertyChanged: OnIconChanged);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.CreateAttached("Size", typeof(double), typeof(FontIcon), 12.0, propertyChanged: OnIconChanged);

        private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            string fontFamily = null;
            string glyph = null;
            string selector = (string)bindable.GetValue(IconProperty);
            if(!string.IsNullOrEmpty(selector) && FontRegistry.HasFont(selector, out var font))
            {
                fontFamily = font.FontFileName;
                glyph = font.GetGlyph(selector);
            }

            switch (bindable)
            {
                case Label label:
                    label.Text = glyph;
                    label.FontFamily = fontFamily;
                    break;
                case Button btn:
                    btn.Text = glyph;
                    btn.FontFamily = fontFamily;
                    break;
                case Span span:
                    span.Text = glyph;
                    span.FontFamily = fontFamily;
                    break;
                case MenuItem menuItem:
                    menuItem.IconImageSource = CreateIconImageSource(bindable, selector);
                    break;
                default:
                    FontRegistry.OnChanged?.Invoke(bindable, selector, glyph, fontFamily);
                    break;
            }
        }

        public static IconImageSource CreateIconImageSource(BindableObject bindable, string selector) => 
            new IconImageSource
            {
                Name = selector,
                Size = (double)bindable.GetValue(SizeProperty),
                Color = (Color)bindable.GetValue(ColorProperty)
            };

        public static string GetIcon(BindableObject bindable) =>
            (string)bindable.GetValue(IconProperty);

        public static void SetIcon(BindableObject bindable, string selector) =>
            bindable.SetValue(IconProperty, selector);

        public static Color GetColor(BindableObject bindable) =>
            (Color)bindable.GetValue(ColorProperty);

        public static void SetColor(BindableObject bindable, Color color) =>
            bindable.SetValue(ColorProperty, color);

        public static double GetSize(BindableObject bindable) =>
            (double)bindable.GetValue(SizeProperty);

        public static void SetSize(BindableObject bindable, double size) =>
            bindable.SetValue(SizeProperty, size);
    }
}
