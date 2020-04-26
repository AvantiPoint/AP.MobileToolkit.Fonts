using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace AP.MobileToolkit.Fonts.Platform.Droid
{
    public abstract class PlatformEffect<TEffect, TElement, TControl> : PlatformEffect
        where TEffect : RoutingEffect
        where TElement : View
        where TControl : Android.Views.View
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
