using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AP.MobileToolkit.Fonts
{
    internal abstract class GeneratedFont : IFont
    {
        public string Alias { get; protected set; }
        public string FontFileName { get; protected set; }
        public string Prefix { get; protected set; }

        protected IDictionary<string, string> _mappings;

        public string GetGlyph(string name)
        {
            if (_mappings.ContainsKey(name))
            {
                return _mappings[name];
            }

            if (Regex.IsMatch(name.Trim(), @"\s"))
            {
                return GetGlyph(name.Trim().Split(' ')[1]);
            }

            if (HasKey(out var key, name, Regex.Replace(name, @"(-)", string.Empty)))
            {
                return _mappings[key];
            }

            return string.Empty;
        }

        private bool HasKey(out string key, params string[] searchNames)
        {
            key = null;
            foreach (var name in searchNames)
            {
                key = _mappings.Keys.FirstOrDefault(x => x.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(key))
                {
                    return true;
                }

                var prefixedName = $"{Prefix}-{name}";
                key = _mappings.Keys.FirstOrDefault(x => x.Equals(prefixedName, StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
