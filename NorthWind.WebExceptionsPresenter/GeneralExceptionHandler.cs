using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Nortwind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHanlderBase, IExceptionHandler
    {
        public Task handler(ExceptionContext context)
        {
            var _Exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError, _Exception.Message, _Exception.Details);
        }
    }
}
