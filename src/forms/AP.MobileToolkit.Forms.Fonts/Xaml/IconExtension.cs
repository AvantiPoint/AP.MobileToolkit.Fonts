using System;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP.MobileToolkit.Xaml
{
    [ContentProperty(nameof(IconName))]
    public class IconExtension : IMarkupExtension<string>
    {
        public string IconName { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException("The IconGlyphExtension requires a ServiceProvider");
            }

            if (FontRegistry.HasFont(IconName, out var font))
            {
                var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
                var element = provideValueTarget.TargetObject;
                var elementType = element.GetType();
                var fontFamilyProperty = elementType.GetProperty("FontFamily");
                if (fontFamilyProperty is null)
                {
                    throw new NotSupportedException($"The target element {elementType.FullName} does not have a property for the FontFamily. This element is not supported for Icon Glyphs");
                }

                fontFamilyProperty.SetValue(element, font.FontFileName);
                return font.GetGlyph(IconName);
            }

            return "Unknown Icon";
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
