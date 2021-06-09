using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Hosting;

namespace AP.MobileToolkit.Fonts.Controls
{
    public static class FontIcon
    {
        public delegate void FontIconHandler(BindableObject bindable, string selector, string glyph, string fontFamily);

        public static readonly BindableProperty IconProperty =
    BindableProperty.CreateAttached("Icon", typeof(string), typeof(BindableObject), null, propertyChanged: OnIconChanged);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached("Color", typeof(Color), typeof(BindableObject), Colors.Black, propertyChanged: OnIconChanged);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.CreateAttached("Size", typeof(double), typeof(BindableObject), 12.0, propertyChanged: OnIconChanged);

        private static FontIconHandler _defaultOnChanged = DefaultOnChanged;

        private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            string fontFamily = null;
            string glyph = null;
            string selector = (string)bindable.GetValue(IconProperty);
            if (!string.IsNullOrEmpty(selector) && RegistryLocator.Registry is not null && RegistryLocator.Registry.HasFont(selector, out var font))
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
                    _defaultOnChanged?.Invoke(bindable, selector, glyph, fontFamily);
                    break;
            }
        }

            public static void RegisterDefaultOnChangedHandler(FontIconHandler fontIconHandler) =>
            _defaultOnChanged = fontIconHandler;

        public static IconImageSource CreateIconImageSource(BindableObject bindable, string selector) =>
            new()
            {
                Name = selector,
                Size = (double)bindable.GetValue(SizeProperty),
                Color = (Color)bindable.GetValue(ColorProperty)
            };

        private static void DefaultOnChanged(BindableObject bindable, string selector, string glyph, string fontFamily)
        {
            Console.WriteLine($"The control type '{bindable.GetType().FullName}' is not supported. To add support please register a delegate handler or file an issue on GitHub.");
        }
    }
}
