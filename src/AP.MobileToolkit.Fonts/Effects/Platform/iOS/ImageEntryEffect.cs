using System.Drawing;
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Fonts;
using AP.MobileToolkit.Fonts.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(Constants.ResolutionGroupName)]
[assembly: ExportEffect(typeof(AP.MobileToolkit.Effects.Platform.iOS.ImageEntryEffect), nameof(AP.MobileToolkit.Effects.Platform.iOS.ImageEntryEffect))]
#pragma warning disable SA1300
namespace AP.MobileToolkit.Effects.Platform.iOS
#pragma warning restore SA1300
{
    internal class ImageEntryEffect : PlatformEffect<Effects.ImageEntryEffect, Entry, UITextField>
    {
        protected override async void OnAttached()
        {
            ImageSource source;
            if (!string.IsNullOrWhiteSpace(Effect.Icon) && FontRegistry.HasFont(Effect.Icon, out _))
            {
                source = new IconImageSource
                {
                    Color = Effect.LineColor,
                    Name = Effect.Icon,
                    Size = Effect.ImageWidth
                };
            }
            else if (Effect.ImageSource != null)
            {
                source = Effect.ImageSource;
            }
            else
            {
                return;
            }

            var handler = Xamarin.Forms.Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(source);

            if (handler != null)
                SetImage(await handler.LoadImageAsync(source));
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }

        private void SetImage(UIImage image)
        {
            var textField = Control;

            switch (Effect.Alignment)
            {
                case ImageAlignment.Left:
                    textField.LeftViewMode = UITextFieldViewMode.Always;
                    textField.LeftView = GetImageView(image, Effect.ImageHeight, Effect.ImageWidth);
                    break;
                case ImageAlignment.Right:
                    textField.RightViewMode = UITextFieldViewMode.Always;
                    textField.RightView = GetImageView(image, Effect.ImageHeight, Effect.ImageWidth);
                    break;
            }

            textField.BorderStyle = UITextBorderStyle.None;
            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, (float)(Element.HeightRequest - 1), Control.Frame.Width, 1.0f),
                BorderWidth = 2.0f,
                BorderColor = Effect.LineColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        private UIView GetImageView(UIImage image, int height, int width)
        {
            var uiImageView = new UIImageView(image)
            {
                Frame = new RectangleF(0, 0, width, height)
            };
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
            objLeftView.AddSubview(uiImageView);

            return objLeftView;
        }
    }
}
