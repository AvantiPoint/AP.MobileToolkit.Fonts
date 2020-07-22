using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using Windows.UI.Xaml;

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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
