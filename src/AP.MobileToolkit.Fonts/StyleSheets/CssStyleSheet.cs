using System.Collections;
using System.Collections.Generic;

namespace AP.MobileToolkit.Fonts.StyleSheets
{
    internal class CssStyleSheet : ICssStyleSheet
    {
        private readonly List<CssStyle> _styles = new List<CssStyle>();

        public CssStyle this[int index]
        {
            get => _styles[index];
            set => _styles[index] = value;
        }

        public int Count => _styles.Count;

        public bool IsReadOnly => ((IList<CssStyle>)_styles).IsReadOnly;

        public void Add(CssStyle item) => _styles.Add(item);

        public void Clear() => _styles.Clear();

        public bool Contains(CssStyle item) => _styles.Contains(item);

        public void CopyTo(CssStyle[] array, int arrayIndex) => _styles.CopyTo(array, arrayIndex);

        public IEnumerator<CssStyle> GetEnumerator() => ((IList<CssStyle>)_styles).GetEnumerator();

        public int IndexOf(CssStyle item) => _styles.IndexOf(item);

        public void Insert(int index, CssStyle item) => _styles.Insert(index, item);

        public bool Remove(CssStyle item) => _styles.Remove(item);

        public void RemoveAt(int index) => _styles.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => ((IList<CssStyle>)_styles).GetEnumerator();
    }
}
