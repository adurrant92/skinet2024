using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware(IHostEnvironment env, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next (context);
            }
            catch (Exception ex)
            {
                
                await HandelExceptionAsync(context,ex, env);
            }
        }

        private static Task HandelExceptionAsync(HttpContext context, Exception ex, IHostEnvironment env)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var responce = env.IsDevelopment()
            ?  new ApiErrorResponse(context.Response.StatusCode, ex.Message, ex.StackTrace):
            new ApiErrorResponse(context.Response.StatusCode,ex.Message, "internal server error");

            var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            var json = JsonSerializer.Serialize(responce, options);

            return  context.Response.WriteAsync(json);
        }
    }
}