using Base.Core.Enumerators;

namespace Base.Core.Controllers
{
    public class ResponseError
    {
        public int Id { get; set; }
        public ErrorCode Code { get; set; }
        public string Description { get; set; }
    }
}
