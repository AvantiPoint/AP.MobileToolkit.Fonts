namespace AP.MobileToolkit.Fonts.StyleSheets
{
    /// <summary>
    /// Common regular Expressions
    /// </summary>
    internal static class RegularExpressionLibrary
    {
        #region Internet Patterns

        /// <summary>
        /// Matches CSS selectors and returns groups of selector[propertyname:propertyValue]
        /// use to parse CSS in a string or file
        /// http://stackoverflow.com/a/2694121/899290
        /// </summary>
        public const string CSSGroups = @"(?<selector>(?:(?:[^,{]+),?)*?)\{(?:(?<name>[^}:]+):?(?<value>[^};]+);?)*?\}";

        /// <summary>
        /// Regex matching CSS Comments
        /// </summary>
        public const string CSSComments = @"(?<!"")\/\*.+?\*\/(?!"")";

        /// <summary>
        /// Use this RegularExpression to test if an email is in proper format
        /// Set Regular Expression to Case insensitive
        /// Checks if the top level domain is valid
        /// Does not check for valid top level domains only if the pattern is correct.
        /// </summary>
        /// <remarks>http://xyfer.blogspot.com/2005/01/javascript-regexp-email-validator.html</remarks>
        public const string EmailPattern = @"^((""[\w-\s]+"")|([\w-]+(?:\.[\w-]+)*)|(""[\w-\s]+"")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-zA-Z]{2,6}(?:\.[a-zA-Z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)";

        /// <summary>
        /// Use this Regular Expression to test if an email is in proper format
        /// Set Regular Expression to Case Insensitive
        /// Does not check if domains are valid. Does not allow domains
        /// larger than 4 characters long
        /// </summary>
        public const string EmailGeneralPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

        /// <summary>
        /// Standard Public Url and Some Intranet Urls.
        /// Will match
        /// </summary>
        public const string URLPattern = @"^((ht|f)tp(s?)\:\/\/|~/|/)?([\w]+:\w+@)?(([a-zA-Z]{1}([\w\-]+\.)+([\w]{2,5}))|([a-zA-Z]{1}([\w\-]+[^\.])+([\w]{2,5})))(:[\d]{1,5})?|((^(25[0-5]|(2[0-4])\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}))((/?\w+/)+|/?)(\w+\.[\w]{3,4})?((\?\w+(=\w+)?)(&\w+(=\w+)?)*)?";

        /// <summary>
        /// HTTP, FTP, HTTPS, FTPS, network Protocols
        /// </summary>
        public const string NetworkProtocolPattern = @"^((ht|f)tp(s?)\:\/\/|~/|/)";

        #endregion
    }
}
