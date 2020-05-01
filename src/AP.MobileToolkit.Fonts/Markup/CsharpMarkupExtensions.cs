using System;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AP.MobileToolkit.Markup
{
    public static class CSharpMarkupExtensions
    {
        public static TElement SetIcon<TElement>(this TElement element, string icon, Color? color = null)
            where TElement : Element, IFontElement
        {
            if (!FontRegistry.HasFont(icon, out var font))
            {
                return element;
            }

            var glyphColor = color ?? Color.Default;
            var glyph = font.GetGlyph(icon);
            switch (element)
            {
                case Label label:
                    SetIcon(label, font.FontFileName, glyph, glyphColor);
                    break;
                case Span span:
                    SetIcon(span, font.FontFileName, glyph, glyphColor);
                    break;
                case Editor editor:
                    SetIcon(editor, font.FontFileName, glyph, glyphColor);
                    break;
                case Button button:
                    SetIcon(button, font.FontFileName, glyph, glyphColor);
                    break;
                case SearchBar searchBar:
                    SetIcon(searchBar, font.FontFileName, glyph, glyphColor);
                    break;
            }
            return element;
        }

        public static FontImageSource SetIcon(this FontImageSource imageSource, string icon, Color? color = null)
        {
            if (FontRegistry.HasFont(icon, out var font))
            {
                imageSource.Glyph = font.GetGlyph(icon);
                imageSource.FontFamily = font.FontFileName;
                imageSource.Color = color ?? Color.Default;
            }

            return imageSource;
        }

        private static void SetIcon(Label element, string fontFamily, string glyph, Color color)
        {
            element.Text = glyph;
            element.FontFamily = fontFamily;
            element.TextColor = color;
        }

        private static void SetIcon(Span element, string fontFamily, string glyph, Color color)
        {
            element.Text = glyph;
            element.FontFamily = fontFamily;
            element.TextColor = color;
        }

        private static void SetIcon(Editor element, string fontFamily, string glyph, Color color)
        {
            element.Text = glyph;
            element.FontFamily = fontFamily;
            element.TextColor = color;
        }

        private static void SetIcon(Button element, string fontFamily, string glyph, Color color)
        {
            element.Text = glyph;
            element.FontFamily = fontFamily;
            element.TextColor = color;
        }

        private static void SetIcon(SearchBar element, string fontFamily, string glyph, Color color)
        {
            // TODO: We'll want to introduce an effect that adds the icon to the Search Bar rather than setting the text.
            element.Text = glyph;
            element.FontFamily = fontFamily;
            element.TextColor = color;
        }

        private static void SetIcon(SearchHandler element, string fontFamily, string glyph, Color color)
        {
            element.QueryIcon = new FontImageSource
            {
                Glyph = glyph,
                FontFamily = fontFamily,
                Color = color
            };
        }

        private class CsharpCodeHelper : IProvideValueTarget, IServiceProvider
        {
            public CsharpCodeHelper(object targetObject)
            {
                TargetObject = targetObject;
            }

            public object TargetObject { get; }

            public object TargetProperty => null;

            public object GetService(Type serviceType)
            {
                return this;
            }
        }
    }
}
