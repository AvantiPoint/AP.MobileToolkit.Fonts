using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace AP.MobileToolkit.Fonts.Controls
{
    public interface IIconImageSource : IImageSource
    {
        string Name { get; }
        double Size { get; }
        Color Color { get; }
    }
}
