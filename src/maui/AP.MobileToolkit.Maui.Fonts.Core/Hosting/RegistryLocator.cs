using System;
using AP.MobileToolkit.Fonts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Maui.Hosting
{
    internal class RegistryLocator : IMauiServiceBuilder
    {
        public static IFontRegistry Registry { get; set; }

        public void Configure(HostBuilderContext context, IServiceProvider services)
        {
            Registry = services.GetRequiredService<IFontRegistry>();
        }

        public void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
        }
    }
}
