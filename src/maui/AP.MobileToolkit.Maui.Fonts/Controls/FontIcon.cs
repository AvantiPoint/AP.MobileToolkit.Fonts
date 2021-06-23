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
    }
}
