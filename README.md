# AP.MobileToolkit.Fonts

AP.MobileTookit.Fonts is designed to make it easier to consume fonts. We currently provide Font Awesome Free as an available installable font. Each font ships with a Mapping class for those who prefer strongly typed XAML.

In addition to a mapping class the fonts all ship with the css shipped with Font Awesome allowing us to easily reuse the same syntax that you may be used to with a web font.

## Download

You can add the MyGet CI feed to nuget by adding it as a source in Visual Studio:

`https://www.myget.org/F/apmobiletoolkit/api/v3/index.json`

Or you can add a NuGet.config to your solution like the following:

```xml
<configuration>
  <packageSources>
    <clear />
    <add key="AP.MobileToolkit" value="https://www.myget.org/F/apmobiletoolkit/api/v3/index.json" />
    <add key="NuGet.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

| Package | NuGet.org | MyGet.org |
|---------|:---------:|:---------:|
| AP.MobileToolkit.Forms.Fonts | [![CoreFontsShield]][CoreFontsNuGet] | [![CoreFontsMyGetShield]][CoreFontsMyGet] |
| AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Brands | [![FABrandsShield]][FABrandsNuGet] | [![FABrandsMyGetShield]][FABrandsMyGet] |
| AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Regular | [![FARegularShield]][FARegularNuGet] | [![FARegularMyGetShield]][FARegularMyGet] |
| AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Solid | [![FASolidShield]][FASolidNuGet] | [![FASolidMyGetShield]][FASolidMyGet] |

## How this works

This utilizes the Embedded Fonts feature in Xamarin.Forms 4.5 and has it's own FontRegistry that it uses to handle font registrations. In order to use it, in your application simply register font's either shipped as part of the toolkit or that you have created on your own.

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
    <Image Source="{FontImage Glyph={ap:Icon 'far fa-check-circle'}, Color=Blue, Size=60}" />
  </StackLayout>
</ContentPage>
```

You can also use a built-in static class to enable IntelliSense, strong typing, and compile checking for glyphs.

```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:ap="http://avantipoint.com/mobiletoolkit"
             x:Class="SampleFonts.MainPage">
  <StackLayout>
    <Label Text="{ap:Icon IconName={x:Static ap:FontAwesomeRegular.User}}" />
    <Button Text="{ap:Icon IconName={x:Static ap:FontAwesomeRegular.User}}" />
    <Image Source="{FontImage Glyph={x:Static ap:FontAwesomeRegular.CheckCircle}, Color=Blue, Size=60}" />
  </StackLayout>
</ContentPage>
```

**NOTE** The Icon extension will work on any Element that has both a Text and FontFamily property. Both are set automatically. This does not work with the ToolbarItem as it does not have a FontFamily property. If using a ToolbarItem be sure to use the FontImageSource.

[CoreFontsShield]: https://img.shields.io/nuget/vpre/AP.MobileToolkit.Forms.Fonts.svg
[CoreFontsNuGet]: https://www.nuget.org/packages/AP.MobileToolkit.Forms.Fonts
[CoreFontsMyGetShield]: https://img.shields.io/myget/apmobiletoolkit/vpre/AP.MobileToolkit.Forms.Fonts.svg
[CoreFontsMyGet]: https://www.myget.org/feed/apmobiletoolkit/package/nuget/AP.MobileToolkit.Forms.Fonts

[FABrandsShield]: https://img.shields.io/nuget/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Brands.svg
[FABrandsNuGet]: https://www.nuget.org/packages/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Brands
[FABrandsMyGetShield]: https://img.shields.io/myget/apmobiletoolkit/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Brands.svg
[FABrandsMyGet]: https://www.myget.org/feed/apmobiletoolkit/package/nuget/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Brands

[FARegularShield]: https://img.shields.io/nuget/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Regular.svg
[FARegularNuGet]: https://www.nuget.org/packages/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Regular
[FARegularMyGetShield]: https://img.shields.io/myget/apmobiletoolkit/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Regular.svg
[FARegularMyGet]: https://www.myget.org/feed/apmobiletoolkit/package/nuget/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Regular

[FASolidShield]: https://img.shields.io/nuget/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Solid.svg
[FASolidNuGet]: https://www.nuget.org/packages/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Solid
[FASolidMyGetShield]: https://img.shields.io/myget/apmobiletoolkit/vpre/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Solid.svg
[FASolidMyGet]: https://www.myget.org/feed/apmobiletoolkit/package/nuget/AP.MobileToolkit.Forms.Fonts.FontAwesomeFree.Solid
