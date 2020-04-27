# AP.MobileToolkit.Fonts

AP.MobileTookit.Fonts is designed to make it easier to consume fonts. We currently provide Font Awesome Free as an available installable font. Each font ships with a Mapping class for those who prefer strongly typed XAML.

In addition to a mapping class the fonts all ship with the css shipped with Font Awesome allowing us to easily reuse the same syntax that you may be used to with a web font.

## How this works

This utilizes the Embedded Fonts feature in Xamarin.Forms 4.5 and has it's own FontRegistry. In order to use it, in your application simply register font's either shipped as part of the toolkit or that you have created on your own.

```cs
public partial class App : Application
{
    public App()
    {
        FontRegistry.RegisterFonts(
            FontAwesomeBrands.Font,
            FontAwesomeRegular.Font,
            FontAwesomeSolid.Font);

        InitializeComponent();

        MainPage = new MainPage();
    }
}
```

Because we cross-compile AP.MobileToolkit.Fonts there is no need to do any platform init to keep any of the native plumbing from being stripped out by the linker.

Using it in your XAML couldn't be easier:

```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:ap="http://avantipoint.com/mobiletoolkit"
             x:Class="SampleFonts.MainPage">
  <StackLayout>
    <Label Text="{ap:Icon 'far fa-user'}" />
    <Button Text="{ap:Icon 'far fa-user'}" />
  </StackLayout>
</ContentPage>
```

**NOTE** The Icon extension will work on any Element that has both a Text and FontFamily property. Both are set automatically. This does not work with the ToolbarItem as it does not have a FontFamily property.