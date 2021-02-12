using Base.Core.Paging;

namespace Base.Core.Results
{
    public class ResultPaging<T>
    {

        public bool IsValid { get; set; }
        public Page<T> Response { get; set; }
        public Error Errors { get; set; }
    }
}
