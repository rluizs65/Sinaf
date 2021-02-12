using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Base.Core.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                if (context.Request.Path.HasValue && !context.Request.Path.Value.Contains("favicon.ico"))
                {
                    if (context.Response.StatusCode == 400)
                        throw new BadRequestException("Bad Request");
                }

                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is NotFoundException)
                code = HttpStatusCode.NotFound;
            else if (exception is BadRequestException)
                code = HttpStatusCode.BadRequest;

            var ex = exception.GetType();
            var result = (new ErrorDetail 
            { 
                Message = exception.Message, 
                StatusCode = (int)code 
            }).ToString();

            _logger.LogError($"{context.Request.Path} - {result} - Data : {DateTime.Now}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
