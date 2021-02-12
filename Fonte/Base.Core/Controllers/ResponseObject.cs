using System.Collections.Generic;

namespace Base.Core.Controllers
{
    public class ResponseObject
    {
        public int StatusCode { get; set; }
        public List<ResponseError> Error { get; set; }

        public ResponseObject()
        {
            Error = new List<ResponseError>();
        }
    }
}
