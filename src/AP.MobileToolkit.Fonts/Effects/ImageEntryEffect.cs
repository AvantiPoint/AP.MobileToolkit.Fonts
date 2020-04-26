using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using Xamarin.Forms;

namespace AP.MobileToolkit.Effects
{
    public class ImageEntryEffect : RoutingEffect
    {
        public ImageEntryEffect()
            : base(Constants.GetEffectName(nameof(ImageEntryEffect)))
        {
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource ImageSource { get; set; }

        public string Icon { get; set; }

        [TypeConverter(typeof(ColorTypeConverter))]
        public Color LineColor { get; set; }

        public int ImageHeight { get; set; }

        public int ImageWidth { get; set; }

        public ImageAlignment Alignment { get; set; }
    }
}
