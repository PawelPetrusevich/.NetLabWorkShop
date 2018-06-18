using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocket.Web.Filter
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public string Message { get; set; }

        public Type ExceptionType { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public override Task OnExceptionAsync(
            HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == ExceptionType)
            {
                this.Message = "Sorry, Error";
#if DEBUG
                this.Message = GetErrorMessage(actionExecutedContext.Exception);
#endif
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.Message);
            }

            return Task.FromResult<object>(null);
        }

        private string GetErrorMessage(Exception Exception)
        {
            if (Exception.InnerException == null)
            {
                return Exception.Message;
            }
            else
            {
                return GetErrorMessage(Exception.InnerException);
            }
        }
    }
}