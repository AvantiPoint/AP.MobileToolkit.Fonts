using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AP.MobileToolkit.Fonts
{
    public abstract class GeneratedFont : IFont
    {
        public readonly object locker = new object();
        public string Alias { get; protected set; }
        public string FontFileName { get; protected set; }
        public string Prefix { get; protected set; }
        protected internal IDictionary<string, string> _mappings;

        public string GetGlyph(string name)
        {
            lock(locker)
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
            }

            return string.Empty;
        }

        private bool HasKey(out string key, params string[] searchNames)
        {
            key = null;
            foreach (var name in searchNames)
            {
                key = _mappings.Keys.FirstOrDefault(x =>
                    x.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                    name.Equals($"{Prefix}-{x}", StringComparison.InvariantCultureIgnoreCase) ||
                    x.Replace("-", string.Empty).Equals(name, StringComparison.InvariantCultureIgnoreCase));
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

                if (!name.Contains('-') && name.Where(x => char.IsUpper(x)).Count() > 1)
                {
                    var searchKey = string.Empty;
                    for (int i = 0; i < name.Length; i++)
                    {
                        searchKey += i > 0 && char.IsUpper(name[i]) ? $"-{name[i]}" : $"{name[i]}";
                    }

                    return HasKey(out key, searchKey.ToLower());
                }
                else if (name.StartsWith($"{Alias}-"))
                {
                    return HasKey(out key, name.Substring($"{Alias}-".Length));
                }
            }
            return false;
        }
    }
}
