using System;
#if WINDOWS_UWP
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
#else
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
#endif



namespace AP.MobileToolkit.Controls
{
    public class IconImageSource : ImageSource
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(
                nameof(Name), typeof(string), typeof(IconImageSource),
                new PropertyMetadata(null, OnIconValueChanged));

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register(
                nameof(Size), typeof(double), typeof(IconImageSource),
                new PropertyMetadata(12.0, OnIconValueChanged));

        //public static readonly DependencyProperty ColorProperty =
        //    DependencyProperty.Register(
        //        nameof(Color), typeof(Color), typeof(IconImageSource),
        //        new PropertyMetadata(Color.Default, OnIconValueChanged));

        private static void OnIconValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is IconImageSource imageSource)
            {

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

        //public Color Color
        //{
        //    get => (Color)GetValue(ColorProperty);
        //    set => SetValue(ColorProperty, value);
        //}
    }
}
