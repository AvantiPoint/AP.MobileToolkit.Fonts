using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using AP.MobileToolkit.Fonts.Controls;

namespace AP.MobileToolkit.Fonts.Xaml
{
    [AcceptEmptyServiceProvider]
    [ContentProperty(nameof(Name))]
    public sealed class IconImageSourceExtension : IconImageSource, IMarkupExtension<IconImageSource>
    {
        public IconImageSource ProvideValue(IServiceProvider serviceProvider) => this;

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
