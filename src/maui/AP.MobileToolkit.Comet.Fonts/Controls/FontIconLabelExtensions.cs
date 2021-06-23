using Comet;
using Microsoft.Maui.Graphics;

namespace AP.MobileToolkit.Fonts.Controls
{
    public static class FontIconExtensions
    {
        public static Text WithFontIcon(this Text text, string selector, double size = -1)
        {
            return text.SetEnvironment(KnownPropertyNames.Icon, selector, cascades: false);
        }

        public static Button WithFontIcon(this Button button, string selector, double size = -1)
        {
            return button.SetEnvironment(KnownPropertyNames.Icon, selector, cascades: false);
        }

        public static Image WithFontIcon(this Image image, string selector, Color color, double size = 20)
        {
            return image.SetEnvironment("Source",
                new IconImageSource
                {
                    Color = color,
                    Size = size,
                    Name = selector
                },
                cascades: false);
        }
    }
}
