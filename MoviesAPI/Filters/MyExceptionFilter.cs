using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public ILogger<MyExceptionFilter> Logger { get; }

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
        {
            Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            Logger.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }
    }
}
