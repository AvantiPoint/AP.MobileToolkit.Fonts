using AP.MobileToolkit.Fonts;
#if !WINDOWS_UWP
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

namespace AP.MobileToolkit.Controls
{
    public partial class IconBlock : ContentControl
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
