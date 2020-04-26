using System;
using AP.MobileToolkit.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP.MobileToolkit.Xaml
{
    [AcceptEmptyServiceProvider]
    [ContentProperty(nameof(Name))]
    public sealed class IconFontSourceExtension : IconImageSource, IMarkupExtension<IconImageSource>
    {
        public IconImageSource ProvideValue(IServiceProvider serviceProvider) => this;

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
