using System;
using System.Collections.Generic;
using System.Text;
#if !WINDOWS_UWP
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
#endif

namespace AP.MobileToolkit.Controls
{
    public class IconExtension : MarkupExtension
    {
        //public static readonly DependencyProperty SelectorProperty =
        //    DependencyProperty.Register(nameof(Selector), typeof(string), typeof(IconExtension), new PropertyMetadata(null));

        //public string Selector
        //{
        //    get => (string)GetValue(SelectorProperty);
        //    set => SetValue(SelectorProperty, value);
        //}

        protected override object ProvideValue()
        {
            return null;
        }
    }
}
