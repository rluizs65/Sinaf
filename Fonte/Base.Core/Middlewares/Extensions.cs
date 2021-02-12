using Microsoft.AspNetCore.Builder;

namespace Base.Core.Middlewares
{
    public static class Extensions
    {
        public static void ConfigureErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
