using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AP.MobileToolkit.Fonts.Controls
{
    public static class FontIcon
    {
        public static readonly BindableProperty IconProperty =
            BindableProperty.CreateAttached(KnownPropertyNames.Icon, typeof(string), typeof(BindableObject), null);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached(KnownPropertyNames.Color, typeof(Color), typeof(BindableObject), Colors.Black);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.CreateAttached(KnownPropertyNames.Size, typeof(double), typeof(BindableObject), 12.0);

        public static string GetIcon(BindableObject bindable) =>
            (string)bindable.GetValue(IconProperty);

        public static void SetIcon(BindableObject bindable, string icon) =>
            bindable.SetValue(IconProperty, icon);

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
