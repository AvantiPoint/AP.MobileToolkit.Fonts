using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Controls;

namespace AP.MobileToolkit.Fonts.Controls
{
    public sealed class IconSpan : Span
    {
        public static readonly BindableProperty GlyphNameProperty =
            BindableProperty.Create(nameof(GlyphName), typeof(string), typeof(IconSpan), null, BindingMode.OneTime, propertyChanged: OnGlyphNameChanged);

        private static void OnGlyphNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is IconSpan span && FontRegistry.HasFont(span.GlyphName, out var font))
            {
                span.FontFamily = font.FontFileName;
                span.Text = font.GetGlyph(span.GlyphName);
            }
            else if (bindable is Span baseSpan)
            {
                baseSpan.FontFamily = null;
                baseSpan.Text = null;
            }
        }

        public string GlyphName
        {
            get => (string)GetValue(GlyphNameProperty);
            set => SetValue(GlyphNameProperty, value);
        }
    }
}
