using System;
using System.Collections.Generic;
using System.Text;
using AP.MobileToolkit.Fonts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AP.MobileToolkit.Controls
{
    public class IconBlock : ContentControl
    {
        public static readonly DependencyProperty SelectorProperty =
            DependencyProperty.Register(nameof(Selector), typeof(string), typeof(IconBlock), new PropertyMetadata(null, OnSelectorChanged));

        private static void OnSelectorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!string.IsNullOrEmpty((string)args.NewValue) 
                && FontRegistry.HasFont((string)args.NewValue, out var font) 
                && dependencyObject is IconBlock iconBlock)
            {
                
            }
        }

        public string Selector
        {
            get => (string)GetValue(SelectorProperty);
            set => SetValue(SelectorProperty, value);
        }
    }
}
