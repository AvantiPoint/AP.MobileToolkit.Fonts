using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
#if !NETSTANDARD
using AP.MobileToolkit.Controls;
using AP.MobileToolkit.Platform;
#endif

[assembly: Preserve(AllMembers = true)]
[assembly: XmlnsPrefix("http://avantipoint.com/mobiletoolkit", "ap")]
[assembly: XmlnsDefinition("http://avantipoint.com/mobiletoolkit", "AP.MobileToolkit.Controls")]
[assembly: XmlnsDefinition("http://avantipoint.com/mobiletoolkit", "AP.MobileToolkit.Xaml")]

#if XAMARIN_IOS || MONOANDROID
[assembly: ExportImageSourceHandler(typeof(IconImageSource), typeof(IconImageSourceHandler))]
#elif UWP
[assembly: Xamarin.Forms.Platform.UWP.ExportImageSourceHandler(typeof(IconImageSource), typeof(IconImageSourceHandler))]
#endif

[assembly: InternalsVisibleTo("AP.MobileToolkit.Fonts.Tests")]
