using Base.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Base.Core.Enumerators;

namespace Base.Core.Controllers
{
    public class BaseController : ControllerBase
    {
        public new ResponseObject Response { get; set; }

        public BaseController()
        {
            Response = new ResponseObject();
        }

        protected void AddErrorResponse(string errorMessage)
        {
            Response.StatusCode = System.Net.HttpStatusCode.Conflict.GetValue<int>();

            Response.Error.Add(new ResponseError()
            {
                Code = ErrorCode.EXCEPTION_ERROR,
                Description = errorMessage
            });
        }

        protected void AddErrorResponse(ErrorCode errorCode)
        {
            if (errorCode == ErrorCode.ERROR_RECORD_NOT_FOUND)
                Response.StatusCode = System.Net.HttpStatusCode.NoContent.GetValue<int>();
            else
                Response.StatusCode = System.Net.HttpStatusCode.Conflict.GetValue<int>();

            Response.Error.Add(new ResponseError()
            {
                Code = errorCode,
                Description = errorCode.GetAttributeDescription()
            });
        }

        protected void AddErrorResponse(int id, ErrorCode errorCode)
        {
            if (errorCode == ErrorCode.ERROR_RECORD_NOT_FOUND)
                Response.StatusCode = System.Net.HttpStatusCode.NoContent.GetValue<int>();
            else
                Response.StatusCode = System.Net.HttpStatusCode.Conflict.GetValue<int>();

            Response.Error.Add(new ResponseError()
            {
                Id = id,
                Code = errorCode,
                Description = errorCode.GetAttributeDescription()
            });
        }
    }
}
