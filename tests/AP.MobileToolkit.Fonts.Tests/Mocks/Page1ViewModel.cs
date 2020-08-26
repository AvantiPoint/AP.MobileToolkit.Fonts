using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts.Tests.Mocks
{
    public class Page1ViewModel
    {
        public Page1ViewModel()
            : this("test foo", "test foo-bar")
        {
        }

        public Page1ViewModel(params string[] icons)
        {
            Icons = icons;
        }

        public IEnumerable<string> Icons { get; }
    }
}
