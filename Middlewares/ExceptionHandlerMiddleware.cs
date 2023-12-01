using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using NHNT.Exceptions;
using NHNT.Dtos;
using NHNT.Constants.Statuses;

namespace NHNT.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DataRuntimeException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                DataResponse<object> response = DataResponse<object>.Build(ex.ErrorCode, ex.ErrorMessage);
                await context.Response.WriteAsync(response.ToString());
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                DataResponse<string> response = DataResponse<string>.Build(StatusServer.INTERNAL_SERVER_ERROR, ex.Message);
                await context.Response.WriteAsync(response.ToString());
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                context.Response.ContentType = "application/json";
                DataResponse<string> response = DataResponse<string>.Build(StatusServer.FORBIDDEN);
                await context.Response.WriteAsync(response.ToString());
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.ContentType = "application/json";
                DataResponse<string> response = DataResponse<string>.Build(StatusServer.TOKEN_EXPIRED);
                await context.Response.WriteAsync(response.ToString());
                // context.Response.Redirect("/Error/404"); // sau này có thể tạo trang nào đó thay thế
            }
        }
    }
}