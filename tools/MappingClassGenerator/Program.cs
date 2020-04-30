using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;
using AP.MobileToolkit.Fonts.StyleSheets;
using Humanizer;

namespace MappingClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var bundledFont in BundledFonts)
            {
                var relativePath = Path.Combine("Resources", bundledFont.FontFile);
                var basePath = Directory.GetCurrentDirectory();
                var fontFilePath = Path.Combine(basePath, relativePath);
                if(!File.Exists(fontFilePath))
                {
                    basePath =new FileInfo(typeof(Program).Assembly.Location).DirectoryName;
                    fontFilePath = Path.Combine(basePath, relativePath);
                }

                var glyph = new GlyphTypeface(new Uri(fontFilePath));

                var mappings = string.IsNullOrEmpty(bundledFont.CssFile) ? HandleNonWebFont(glyph, bundledFont) : HandleWebFont(glyph, bundledFont, basePath);
                var properties = mappings.Select(x => {
                    if(x.Key == "Equals")
                        return $"        public new const string {x.Key} = \"{x.Value}\";";
                    return $"        public const string {x.Key} = \"{x.Value}\";";
                });
                var file = $@"namespace AP.MobileToolkit.Fonts.Mappings
{{
    public static class {bundledFont.Name}
    {{
{string.Join("\n", properties)}
    }}
}}
".Replace("\r\n", "\n");
                var fileInfo = new FileInfo(Path.Combine("mappings", $"{bundledFont.Name}.cs"));
                Console.WriteLine($"Generating {fileInfo.FullName}");
                Console.WriteLine(file);
                fileInfo.Directory.Create();
                File.WriteAllText(fileInfo.FullName, file);
            }
        }

        private static Dictionary<string, string> HandleWebFont(GlyphTypeface glyphTypeface, BundledFont bundledFont, string basePath)
        {
            var glyphs = new Dictionary<string, string>();
            var styles = new CssParser(File.ReadAllText(Path.Combine(basePath, "Resources", bundledFont.CssFile))).Styles;
            foreach (var ctg in glyphTypeface.CharacterToGlyphMap)
            {
                var unicode = $"\\{ctg.Key:x}";
                var locatedStyle = styles.FirstOrDefault(x => x.Styles.Any(s => s.Key == "content" && s.Value.Contains(unicode)));
                if (locatedStyle is null)
                {
                    Console.WriteLine($"Could not locate resource for glyph {unicode}");
                    System.Diagnostics.Debugger.Break();
                }

                var mappedValue = Regex.Replace(locatedStyle.SelectorText, @"^(\.)", string.Empty).Split(':').First();
                var propertyName = Regex.Replace(mappedValue, $@"^{bundledFont.Prefix}(-)?", string.Empty).Replace('-', '_').Pascalize();
                mappedValue = $"{bundledFont.Alias} {mappedValue}".Trim();

                if (char.IsDigit(propertyName[0]))
                {
                    var numeric = string.Empty;
                    for (var i = 0; i < propertyName.Length; i++)
                    {
                        var c = propertyName[i];
                        if (char.IsDigit(c))
                            numeric += c;
                        else
                            break;
                    }

                    var value = int.Parse(numeric);
                    propertyName = $"{value.ToWords()}{propertyName.Substring(numeric.Length).Pascalize()}".Humanize(LetterCasing.Title).Replace(" ", string.Empty);
                }

                glyphs.Add(propertyName, mappedValue);
            }

            return glyphs;
        }

        private static Dictionary<string, string> HandleNonWebFont(GlyphTypeface glyphTypeface, BundledFont bundledFont)
        {
            // TODO: Implement this method
            return new Dictionary<string, string>();
        }

        private static readonly IEnumerable<BundledFont> BundledFonts = new[]
        {
            new BundledFont
            {
                Name = "FontAwesomeRegular",
                Alias = "far",
                Prefix = "fa",
                FontFile = "fa-regular-400.ttf",
                CssFile = "fontawesome.min.css"
            },
            new BundledFont
            {
                Name = "FontAwesomeSolid",
                Alias = "fas",
                Prefix = "fa",
                FontFile = "fa-solid-900.ttf",
                CssFile = "fontawesome.min.css"
            },
            new BundledFont
            {
                Name = "FontAwesomeBrands",
                Alias = "fab",
                Prefix = "fa",
                FontFile = "fa-brands-400.ttf",
                CssFile = "fontawesome.min.css"
            }
        };
    }
}
