using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiErrorHandling.Core
{
    public class BusinessErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public BusinessErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex is IBusinessException exception && ex is HttpResponseException)
            {
                context.Response.StatusCode = (int)((HttpResponseException)ex).Response.StatusCode;
                ///https://tools.ietf.org/html/rfc7807
                context.Response.ContentType = "application/problem+json";
                var json = JsonSerializer.Serialize(exception.ProblemDetails);
                return context.Response.WriteAsync(json);
            }
            else
            {
                var result = JsonSerializer.Serialize(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //(or maybe ExpectationFailed);
                return context.Response.WriteAsync(result);
            }
        }
    }
}
