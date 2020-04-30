using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AP.MobileToolkit.Fonts.StyleSheets
{
    internal static class ICssParserExtensions
    {
        /// <summary>
        /// Reads the CSS file.
        /// </summary>
        /// <param name="stream">The file stream.</param>
        public static void ReadCSSFile(this ICssParser parser, Stream stream)
        {
            using var reader = new StreamReader(stream);
            parser.ReadCSSFile(reader);
        }

        /// <summary>
        /// Reads the CSS file.
        /// </summary>
        /// <param name="Path">The path.</param>
        public static void ReadCSSFile(this ICssParser parser, string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open);
            parser.ReadCSSFile(stream);
        }

        public static void ReadCSSFile(this ICssParser parser, string resourceName, Type resolvingType) =>
            parser.ReadCSSFile(resourceName, resolvingType.Assembly);

        /// <summary>
        /// Reads a css file from a given assembly
        /// </summary>
        /// <param name="parser">The <see cref="ICssParser"/> instance</param>
        /// <param name="resourceName">The CSS file name 'sample.css' or 'sample.min.css'</param>
        /// <param name="assembly">The <see cref="Assembly"/> the file is embedded in</param>
        public static void ReadCSSFile(this ICssParser parser, string resourceName, Assembly assembly)
        {
            var resourceId = assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase)
                                  || x.EndsWith(resourceName, StringComparison.InvariantCultureIgnoreCase));

            if (string.IsNullOrEmpty(resourceId))
            {
                throw new FileNotFoundException($"The css file {resourceName} could not be found in the assembly {assembly.FullName}");
            }

            using var stream = assembly.GetManifestResourceStream(resourceId);
            parser.ReadCSSFile(stream);
        }

        public static string GetFontIcon(this ICssParser parser, string className)
        {
            if (parser.ContainsClass(className, out var content))
            {
                return content;
            }

            return null;
        }

        private static bool ContainsClass(this ICssParser parser, string className, out string content)
        {
            content = null;
            IDictionary<string, string> styles;
            className = className.Split(new[] { ' ' }).Last();

            var altClassName = AltClassName(className);
            if (parser.Classes.ContainsKey(className))
            {
                styles = parser.Classes[className];
            }
            else if (parser.Classes.ContainsKey(altClassName))
            {
                styles = parser.Classes[altClassName];
            }
            else
            {
                return false;
            }

            if (styles.ContainsKey("content"))
            {
                var asciiValue = Convert.ToInt32(styles["content"].Trim(new[] { '"', '\\' }), 16);
                content = $"{Convert.ToChar(asciiValue)}";
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string AltClassName(string className)
        {
            return Regex.Replace(className, $"^.*-", string.Empty);
        }
    }
}
