using Xamarin.Forms;

[assembly: XmlnsDefinition("http://avantipoint.com/mobiletoolkit", "AP.MobileToolkit.Fonts.Mappings")]

#if XAMARIN_IOS
[assembly: Foundation.LinkerSafe]
#elif MONOANDROID
[assembly: Android.LinkerSafe]
#endif
