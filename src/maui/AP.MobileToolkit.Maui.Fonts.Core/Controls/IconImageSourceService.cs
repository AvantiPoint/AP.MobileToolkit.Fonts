using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace AP.MobileToolkit.Fonts.Controls
{
    public partial class IconImageSourceService : IImageSourceService<IIconImageSource>
    {
#if IOS || ANDROID || WINDOWS || MACCATALYST
        private IFontRegistry _fontRegistry { get; }
        private FontImageSourceService _fontImageSourceService { get; }

        public IconImageSourceService(
            IFontRegistry fontRegistry,
            FontImageSourceService fontImageSourceService)
        {
            _fontRegistry = fontRegistry;
            _fontImageSourceService = fontImageSourceService;
        }

        private IFontImageSource GetFontImageSource(IImageSource imageSource)
        {
            if(imageSource is IIconImageSource iconImageSource && _fontRegistry.HasFont(iconImageSource.Name, out var font))
            {
                return new FontImageSource
                {
                    Glyph = font.GetGlyph(iconImageSource.Name),
                    Font = Font.OfSize(font.FontFileName, iconImageSource.Size),
                    Color = iconImageSource.Color
                };
            }
            else if(imageSource is IFontImageSource fis)
            {
                return fis;
            }

            return new FontImageSource();
        }

        private record FontImageSource : IFontImageSource
        {
            public Color Color { get; init; }
            public Font Font { get; init; }
            public string Glyph { get; init; }
            public bool IsEmpty => string.IsNullOrEmpty(Glyph);
        }
#endif
    }
}
