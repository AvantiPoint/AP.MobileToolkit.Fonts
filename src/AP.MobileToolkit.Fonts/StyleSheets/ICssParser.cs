using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    internal interface ICssParser
    {
        /// <summary>
        /// Gets or Sets Original Style Sheet loaded
        /// </summary>
        string StyleSheet { get; set; }

        /// <summary>
        /// Gets all styles in an Immutable collection
        /// </summary>
        ICssStyleSheet Styles { get; }

        /// <summary>
        /// Gets the CSS classes.
        /// </summary>
        Dictionary<string, Dictionary<string, string>> Classes { get; }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        Dictionary<string, Dictionary<string, string>> Elements { get; }

        /// <summary>
        /// Removes all elements from the <see cref="CssParser"></see>.
        /// </summary>
        void Clear();

        /// <summary>
        /// Reads the specified cascading style sheet.
        /// </summary>
        /// <param name="cascadingStyleSheet">The cascading style sheet.</param>
        void Read(string cascadingStyleSheet);

        /// <summary>
        /// Reads the CSS file.
        /// </summary>
        /// <param name="textReader">The <see cref="TextReader"/> to read the css file.</param>
        void ReadCSSFile(TextReader textReader);
    }
}
