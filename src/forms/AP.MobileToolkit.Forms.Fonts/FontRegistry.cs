using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using AP.MobileToolkit.Fonts.Internals;
using Xamarin.Forms;

namespace AP.MobileToolkit.Fonts
{
    public static class FontRegistry
    {
#if !NETSTANDARD
        private static bool _registered;
#endif

        private static readonly IDictionary<string, IFont> _registeredFonts = new Dictionary<string, IFont>();
        internal static IDictionary<string, IFont> RegisteredFonts => _registeredFonts;

        public static void RegisterFonts(params IFont[] fonts)
        {
#if !NETSTANDARD
            if(!_registered)
            {
                Register(typeof(Controls.IconImageSource), typeof(Platform.IconImageSourceHandler));
            }

            _registered = true;
#endif

            foreach (var font in fonts)
            {
                if (_registeredFonts.ContainsKey(font.Alias))
                {
                    var existingFont = _registeredFonts[font.Alias];
                    if (existingFont.FontFileName == font.FontFileName)
                        continue;

                    throw new InvalidOperationException($"An existing registration already exists for the Alias {font.Alias}. Existing: '{existingFont.FontFileName}' New: '{font.FontFileName}'");
                }

                _registeredFonts.Add(font.Alias, font);
            }
        }

        internal static void Register(Type type, Type renderer)
        {
            var assembly = typeof(Image).Assembly;
            var registrarType = assembly.GetType("Xamarin.Forms.Internals.Registrar") ?? assembly.GetType("Xamarin.Forms.Registrar");
            var registrarProperty = registrarType.GetRuntimeProperty("Registered");

            var registrar = registrarProperty.GetValue(registrarType, null);
            var registerMethod = registrar.GetType().GetRuntimeMethod("Register", new[] { typeof(Type), typeof(Type) });
            registerMethod.Invoke(registrar, new[] { type, renderer });
        }

        internal static IFont LocateFont(string selector)
        {
            return FontRegistryHelper.LocateFont(RegisteredFonts, selector);
        }

        internal static bool HasFont(string selector, out IFont font)
        {
            return FontRegistryHelper.HasFont(RegisteredFonts, selector, out font);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Clear() => _registeredFonts.Clear();
    }
}
