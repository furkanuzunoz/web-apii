using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace programing.API.attiribut
{
    public class exeption : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorresponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            errorresponse.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorresponse;
            base.OnException(actionExecutedContext);
        }
    }
}