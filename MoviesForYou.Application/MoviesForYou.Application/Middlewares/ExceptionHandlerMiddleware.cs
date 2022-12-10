using MoviesForYou.Application.API.ExceptionHandler;
using System.Net;

namespace MoviesForYou.Application.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(NotFoundException exception)
            {
                await setResponseContext(context,exception.Message,HttpStatusCode.NotFound);
            }
            catch(BadRequestException exception)
            {
                await setResponseContext(context,exception.Message,HttpStatusCode.BadRequest);
            }
            catch(InternalServerException exception)
            {
                await setResponseContext(context,exception.Message,HttpStatusCode.InternalServerError);
            }
            catch(Exception exception)
            {
                await setResponseContext(context, exception.Message, HttpStatusCode.InternalServerError);
            }
        }

        private async Task setResponseContext(HttpContext context, string msg, HttpStatusCode httpStatusCode)
        {
            context.Response.StatusCode = (int)httpStatusCode;
            await context.Response.WriteAsync(msg);

        }
    }
}
