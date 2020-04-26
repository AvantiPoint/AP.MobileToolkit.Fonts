using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

#pragma warning disable SA1300
namespace AP.MobileToolkit.Fonts.Platform.iOS
#pragma warning restore SA1300
{
    public abstract class PlatformEffect<TEffect, TElement, TControl> : PlatformEffect
        where TEffect : RoutingEffect
        where TElement : View
        where TControl : UIView
    {
        protected new TElement Element
        {
            get => (TElement)base.Element;
        }

        protected TEffect Effect
        {
            get => (TEffect)Element?.Effects?.FirstOrDefault(e => e is TElement);
        }

        protected new TControl Control
        {
            get => (TControl)base.Control;
        }
    }
}
