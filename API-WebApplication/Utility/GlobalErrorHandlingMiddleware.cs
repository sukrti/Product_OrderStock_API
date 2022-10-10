using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API_WebApplication.Exceptions;
using Microsoft.AspNetCore.Http;
using KeyNotFoundException = API_WebApplication.Exceptions.KeyNotFoundException;
using NotImplementedException = API_WebApplication.Exceptions.NotImplementedException;
using UnauthorizedAccessException = API_WebApplication.Exceptions.UnauthorizedAccessException;
namespace GlobalExceptionHandling.Utility
{
    /// <summary>
    /// GlobalErrorHandlingMiddleware creats a middleware for global execption handling
    /// </summary>
    public class GlobalErrorHandlingMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method accepts HttpContext and delegate the exception to HandleExceptionAsync
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// This method handles all the exceptions
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="exception">Exception</param>
        /// <returns>Task</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = String.Empty;
            string message;
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            var exceptionResult = JsonSerializer.Serialize(new
            {
                error = message,
                stackTrace
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }
        #endregion
    }
}
