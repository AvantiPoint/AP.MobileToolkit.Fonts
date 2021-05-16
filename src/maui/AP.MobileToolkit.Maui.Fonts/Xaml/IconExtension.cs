using System;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace AP.MobileToolkit.Fonts.Xaml
{
    [ContentProperty(nameof(IconName))]
    public class IconExtension : BindableObject, IMarkupExtension<string>
    {
        private const string UnknownIcon = "Unknown Icon";

        public static readonly BindableProperty IconNameProperty =
            BindableProperty.Create(nameof(IconName), typeof(string), typeof(IconExtension), null, propertyChanged: OnIconNameChanged);

        private static void OnIconNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is IconExtension extension)
            {
                extension.UpdateValue();
            }
        }

        private IProvideValueTarget _provideValueTarget;

        public string IconName
        {
            get => (string)GetValue(IconNameProperty);
            set => SetValue(IconNameProperty, value);
        }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException("The IconGlyphExtension requires a ServiceProvider");
            }

            _provideValueTarget = serviceProvider.GetService<IProvideValueTarget>();
            if (_provideValueTarget.TargetObject is Element element)
            {
                SetBinding(BindingContextProperty, new Binding(nameof(BindingContext), BindingMode.OneWay, source: element));
            }

            return ProvideValue();
        }

        private string ProvideValue()
        {
            if (!string.IsNullOrEmpty(IconName) && FontRegistry.HasFont(IconName, out var font))
            {
                var element = _provideValueTarget.TargetObject;
                var elementType = element.GetType();
                var fontFamilyProperty = elementType.GetProperty("FontFamily");
                if (fontFamilyProperty is null)
                {
                    throw new NotSupportedException($"The target element {elementType.FullName} does not have a property for the FontFamily. This element is not supported for Icon Glyphs");
                }

                fontFamilyProperty.SetValue(element, font.FontFileName);
                return font.GetGlyph(IconName);
            }

            return UnknownIcon;
        }

        private void UpdateValue()
        {
            if (_provideValueTarget != null)
            {
                var glyph = ProvideValue();
                if (!string.IsNullOrEmpty(glyph))
                {
                    var targetProperty = _provideValueTarget.TargetProperty as BindableProperty;
                    var element = _provideValueTarget.TargetObject;
                    var elementType = element.GetType();
                    var prop = elementType.GetProperty(targetProperty.PropertyName);
                    if (prop != null)
                    {
                        prop.SetValue(element, glyph);
                    }
                }
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (_provideValueTarget != null && ((propertyName == nameof(BindingContext) && BindingContext != null) || propertyName == nameof(IconName)))
            {
                UpdateValue();
            }
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
