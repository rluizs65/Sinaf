namespace Base.Core.Results
{
    public class Result<T>
    {
        public bool IsValid { get; set; }
        public T Response { get; set; }
        public Error Errors { get; set; }
    }

    public class Result
    {
        public bool IsValid { get; set; }
        public Error Errors { get; set; }
    }
}