using Comet;
using Microsoft.Maui.Graphics;

namespace AP.MobileToolkit.Fonts.Controls
{
    public class IconImageSource : ImageSource, IIconImageSource
    {
        public override bool IsEmpty => !string.IsNullOrEmpty(Name);

        public string Name { get; set; }
        public double Size { get; set; } = 12.0;
        public Color Color { get; set; } = Colors.Black;
    }
}
