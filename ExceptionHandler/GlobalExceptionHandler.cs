using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace apshop.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "We are working on fixing this issue. Thank you for your patience.";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(UserExceptionHandler))
            {
                message = context.Exception.Message.ToString();
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = "We are working on fixing this issue. Thank you for your patience";
                status = HttpStatusCode.InternalServerError;
               
            }
            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
          
            var errormsg = message;
            response.WriteAsync(errormsg);
        }
    }
}
