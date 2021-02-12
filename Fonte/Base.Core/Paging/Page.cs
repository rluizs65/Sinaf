using System.Collections.Generic;

namespace Base.Core.Paging
{
    public class Page<T>
    {
        public IList<T> Rows { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }
}
