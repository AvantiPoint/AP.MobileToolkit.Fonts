using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AP.MobileToolkit.Fonts
{
    public class EmbeddedMappedFont : FontBase
    {
        private static IDictionary<string, string> AnalyzeMappings(Type mappingClassType)
        {
            var fields = mappingClassType.GetFields(BindingFlags.Static | BindingFlags.Public);
            return fields.Where(x => x.FieldType == typeof(string)).ToDictionary(x => x.Name, x => (string)x.GetValue(null));
        }

        internal readonly IDictionary<string, string> _mappings;

        public EmbeddedMappedFont(string fontFileName, string alias, IDictionary<string, string> mappings)
            : base(fontFileName, alias)
        {
            _mappings = mappings;
        }

        public EmbeddedMappedFont(string fontFileName, string alias, Type mappingClassType)
            : this(fontFileName, alias, AnalyzeMappings(mappingClassType))
        {
        }

        public override string GetGlyph(string name)
        {
            if (_mappings.ContainsKey(name))
            {
                return _mappings[name];
            }

            if (Regex.IsMatch(name.Trim(), @"\s"))
            {
                return GetGlyph(name.Trim().Split(' ')[1]);
            }

            name = Regex.Replace(name, $"^({Alias}-)", string.Empty);
            if (_mappings.ContainsKey(name))
            {
                return _mappings[name];
            }

            name = Regex.Replace(name, @"(-)", string.Empty);
            var key = _mappings.Keys.FirstOrDefault(x => x.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }

            return _mappings[key];
        }
    }
}
