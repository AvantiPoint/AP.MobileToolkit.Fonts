using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AP.MobileToolkit.Fonts.StyleSheets
{
    /// <summary>
    /// Object used to parse CSS Files.
    /// This can also be used to minify a CSS file though I
    /// doubt this will pass all the same tests as YUI compressor
    /// or some other tool
    /// </summary>
    internal partial class CssParser : ICssParser
    {
        private const string SelectorKey = "selector";
        private const string NameKey = "name";
        private const string ValueKey = "value";

        /// <summary>
        /// Regular expression to parse the Stylesheet
        /// </summary>
        private readonly Regex rStyles = new Regex(RegularExpressionLibrary.CSSGroups, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private string stylesheet = string.Empty;
        private Dictionary<string, Dictionary<string, string>> classes;
        private Dictionary<string, Dictionary<string, string>> elements;

        /// <summary>
        /// Gets or Sets Original Style Sheet loaded
        /// </summary>
        public string StyleSheet
        {
            get => stylesheet;
            set
            {
                // If the style sheet changes we will clean out any dependant data
                stylesheet = value;
                Clear();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CascadingStyleSheet"/> class.
        /// </summary>
        public CssParser()
        {
            StyleSheet = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CascadingStyleSheet"/> class.
        /// </summary>
        /// <param name="cascadingStyleSheet">The cascading style sheet.</param>
        public CssParser(string cascadingStyleSheet)
        {
            Read(cascadingStyleSheet);
        }

        /// <summary>
        /// Reads the CSS file.
        /// </summary>
        /// <param name="Path">The path.</param>
        public void ReadCSSFile(TextReader textReader)
        {
            StyleSheet = textReader.ReadToEnd();
            Read(StyleSheet);
        }

        /// <summary>
        /// Reads the specified cascading style sheet.
        /// </summary>
        /// <param name="cascadingStyleSheet">The cascading style sheet.</param>
        public void Read(string cascadingStyleSheet)
        {
            Clear();
            StyleSheet = cascadingStyleSheet;

            if (!string.IsNullOrEmpty(cascadingStyleSheet))
            {
                // Remove comments before parsing the CSS. Don't want any comments in the collection. Don't know how iTextSharp would react to CSS Comments
                var matchList = rStyles.Matches(Regex.Replace(cascadingStyleSheet, RegularExpressionLibrary.CSSComments, string.Empty));
                foreach (Match item in matchList)
                {
                    // Check for nulls
                    if (item != null && item.Groups != null && item.Groups[SelectorKey] != null && item.Groups[SelectorKey].Captures != null && item.Groups[SelectorKey].Captures[0] != null && !string.IsNullOrEmpty(item.Groups[SelectorKey].Value))
                    {
                        string strSelector = item.Groups[SelectorKey].Captures[0].Value.Trim();
                        var style = new List<KeyValuePair<string, string>>();

                        for (int i = 0; i < item.Groups[NameKey].Captures.Count; i++)
                        {
                            string className = item.Groups[NameKey].Captures[i].Value;
                            string value = item.Groups[ValueKey].Captures[i].Value;

                            // Check for null values in the properies
                            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(value))
                            {
                                className = className.TrimWhiteSpace();
                                value = value.TrimWhiteSpace();

                                // One more check to be sure we are only pulling valid css values
                                if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(value))
                                {
                                    style.Add(new KeyValuePair<string, string>(className, value));
                                }
                            }
                        }
                        Styles.Add(new CssStyle { SelectorText = strSelector, Styles = style });
                    }
                }
            }
        }

        /// <summary>
        /// Gets the CSS classes.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Classes
        {
            get
            {
                if (classes == null || classes.Count == 0)
                {
                    classes = Styles.Where(cl => cl.SelectorText.StartsWith("."))
                                    .ToDictionary(cl => SanitizeClassSelector(cl.SelectorText),
                                                  cl => cl.Styles.ToDictionary(p => p.Key, p => p.Value));
                }

                return classes;
            }
        }

        private string SanitizeClassSelector(string selectorText)
        {
            var output = selectorText.Trim(new char[] { '.' });
            output = Regex.Replace(output, ":.*", string.Empty);
            return output;
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Elements
        {
            get
            {
                if (elements == null || elements.Count == 0)
                {
                    elements = Styles.Where(el => !el.SelectorText.StartsWith(".")).ToDictionary(el => el.SelectorText, el => el.Styles.ToDictionary(p => p.Key, p => p.Value));
                }
                return elements;
            }
        }

        /// <summary>
        /// Gets all styles in an Immutable collection
        /// </summary>
        public ICssStyleSheet Styles { get; } = new CssStyleSheet();

        /// <summary>
        /// Removes all elements from the <see cref="CssParser"></see>.
        /// </summary>
        public void Clear()
        {
            Styles.Clear();
            classes = null;
            elements = null;
        }

        /// <summary>
        /// Returns a <see cref="string"/> the CSS that was entered as it is stored internally.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var strb = new StringBuilder(StyleSheet.Length);
            foreach (var item in Styles)
            {
                strb.Append(item.SelectorText).Append("{");
                foreach (var property in item.Styles)
                {
                    strb.Append(property.Key).Append(":").Append(property.Value).Append(";");
                }
                strb.Append("}");
            }

            return strb.ToString();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return StyleSheet == null ? 0 : StyleSheet.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        ///   </exception>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (obj is CssParser parser)
            {
                return StyleSheet.Equals(parser.StyleSheet);
            }

            return false;
        }
    }
}
